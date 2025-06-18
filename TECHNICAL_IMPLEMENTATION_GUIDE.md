# DualDeepL Technical Implementation Guide

このドキュメントは、MIGRATION_SPECIFICATION.mdを補完する技術実装ガイドです。実際のコード例と実装パターンを提供します。

## 目次
1. [プロジェクト初期化](#プロジェクト初期化)
2. [TypeScript型定義](#typescript型定義)
3. [React コンポーネント](#reactコンポーネント)
4. [Electron Main Process](#electronmainprocess)
5. [翻訳サービス実装](#翻訳サービス実装)
6. [状態管理実装](#状態管理実装)
7. [設定管理実装](#設定管理実装)

## プロジェクト初期化

### package.json設定例
```json
{
  "name": "dualtrans-electron",
  "version": "1.0.0",
  "description": "Dual translation desktop application",
  "main": "dist/main/main.js",
  "scripts": {
    "start": "electron .",
    "dev": "concurrently \"npm run dev:renderer\" \"npm run dev:main\"",
    "dev:renderer": "vite",
    "dev:main": "tsc -p tsconfig.main.json && electron .",
    "build": "npm run build:renderer && npm run build:main",
    "build:renderer": "vite build",
    "build:main": "tsc -p tsconfig.main.json"
  },
  "dependencies": {
    "electron": "^27.0.0",
    "react": "^18.2.0",
    "react-dom": "^18.2.0",
    "axios": "^1.6.0",
    "zustand": "^4.4.0",
    "antd": "^5.12.0",
    "openai": "^4.20.0"
  },
  "devDependencies": {
    "@types/react": "^18.2.0",
    "@types/react-dom": "^18.2.0",
    "@types/electron": "^1.6.10",
    "typescript": "^5.0.0",
    "vite": "^5.0.0",
    "@vitejs/plugin-react": "^4.0.0",
    "concurrently": "^8.2.0"
  }
}
```

### プロジェクト構造
```
src/
├── main/                 # Electron Main Process
│   ├── main.ts
│   ├── tray.ts
│   ├── shortcuts.ts
│   ├── window.ts
│   └── settings.ts
├── renderer/             # React Renderer Process  
│   ├── App.tsx
│   ├── components/
│   │   ├── TranslationPanel/
│   │   │   ├── index.tsx
│   │   │   ├── OriginalTextPanel.tsx
│   │   │   ├── TranslationResultPanel.tsx
│   │   │   └── styles.module.css
│   │   ├── LanguageSelector/
│   │   │   ├── index.tsx
│   │   │   └── styles.module.css
│   │   ├── InstructionDialog/
│   │   │   ├── index.tsx
│   │   │   └── styles.module.css
│   │   └── Layout/
│   │       ├── Header.tsx
│   │       └── MainLayout.tsx
│   ├── services/
│   │   ├── translationService.ts
│   │   ├── openaiService.ts
│   │   └── deeplService.ts
│   ├── stores/
│   │   ├── translationStore.ts
│   │   └── settingsStore.ts
│   ├── types/
│   │   ├── translation.ts
│   │   ├── language.ts
│   │   └── settings.ts
│   ├── utils/
│   │   ├── errorHandler.ts
│   │   └── debounce.ts
│   └── index.html
├── shared/               # 共通型定義・定数
│   ├── types.ts
│   └── constants.ts
└── assets/
    └── icons/
        └── tray-icon.png
```

## TypeScript型定義

### 言語関連型定義
```typescript
// src/types/language.ts
export interface Language {
  code: string;
  display: string;
}

export type LanguageCode = 
  | "BG" | "CS" | "DA" | "DE" | "EL" | "EN" | "ES" | "ET" 
  | "FI" | "FR" | "HU" | "ID" | "IT" | "JA" | "KO" | "LT" 
  | "LV" | "NB" | "NL" | "PL" | "PT-BR" | "PT-PT" | "RO" 
  | "RU" | "SK" | "SL" | "SV" | "TR" | "UK" | "ZH";

export const SUPPORTED_LANGUAGES: Language[] = [
  { code: "BG", display: "ブルガリア語" },
  { code: "CS", display: "チェコ語" },
  { code: "DA", display: "デンマーク語" },
  { code: "DE", display: "ドイツ語" },
  { code: "EL", display: "ギリシャ語" },
  { code: "EN", display: "英語" },
  { code: "ES", display: "スペイン語" },
  { code: "ET", display: "エストニア語" },
  { code: "FI", display: "フィンランド語" },
  { code: "FR", display: "フランス語" },
  { code: "HU", display: "ハンガリー語" },
  { code: "ID", display: "インドネシア語" },
  { code: "IT", display: "イタリア語" },
  { code: "JA", display: "日本語" },
  { code: "KO", display: "韓国語" },
  { code: "LT", display: "リトアニア語" },
  { code: "LV", display: "ラトビア語" },
  { code: "NB", display: "ノルウェー語" },
  { code: "NL", display: "オランダ語" },
  { code: "PL", display: "ポーランド語" },
  { code: "PT-BR", display: "ポルトガル語 (ブラジル)" },
  { code: "PT-PT", display: "ポルトガル語" },
  { code: "RO", display: "ルーマニア語" },
  { code: "RU", display: "ロシア語" },
  { code: "SK", display: "スロバキア語" },
  { code: "SL", display: "スロベニア語" },
  { code: "SV", display: "スウェーデン語" },
  { code: "TR", display: "トルコ語" },
  { code: "UK", display: "ウクライナ語" },
  { code: "ZH", display: "中国語(簡体字)" }
];
```

### 翻訳関連型定義
```typescript
// src/types/translation.ts
export interface TranslationRequest {
  sourceLang: LanguageCode;
  targetLang: LanguageCode;
  text: string;
  instruction?: string;
}

export interface TranslationResult {
  originalText: string;
  translatedText: string;
  sourceLang: LanguageCode;
  targetLang: LanguageCode;
  reverseTranslation?: string;
  timestamp: Date;
}

export interface DualTranslationResult {
  original: string;
  first: TranslationResult;
  second: TranslationResult;
}

export enum TranslationStatus {
  IDLE = 'idle',
  TRANSLATING = 'translating',
  SUCCESS = 'success',
  ERROR = 'error'
}

export interface TranslationState {
  status: TranslationStatus;
  originalText: string;
  firstTranslation: string;
  secondTranslation: string;
  firstReverseTranslation: string;
  secondReverseTranslation: string;
  error?: string;
}
```

### 設定関連型定義
```typescript
// src/types/settings.ts
export interface AppSettings {
  // API設定
  openaiApiKey: string;
  deeplApiKey: string;
  
  // 言語設定
  originalLanguageIndex: number;
  firstLanguageIndex: number;
  secondLanguageIndex: number;
  
  // カスタム指示
  firstInstruction: string;
  secondInstruction: string;
  
  // UI設定
  alwaysOnTop: boolean;
  windowBounds: {
    x?: number;
    y?: number;
    width: number;
    height: number;
  };
  
  // 動作設定
  typingDelay: number;
  enableGlobalShortcut: boolean;
}

export const DEFAULT_SETTINGS: AppSettings = {
  openaiApiKey: '',
  deeplApiKey: '',
  originalLanguageIndex: 0,
  firstLanguageIndex: 1,
  secondLanguageIndex: 2,
  firstInstruction: '',
  secondInstruction: '',
  alwaysOnTop: false,
  windowBounds: {
    width: 1061,
    height: 800
  },
  typingDelay: 1000,
  enableGlobalShortcut: true
};
```

## React コンポーネント

### メインアプリケーションコンポーネント
```tsx
// src/renderer/App.tsx
import React from 'react';
import { ConfigProvider } from 'antd';
import jaJP from 'antd/locale/ja_JP';
import MainLayout from './components/Layout/MainLayout';
import TranslationPanel from './components/TranslationPanel';
import './App.css';

const App: React.FC = () => {
  return (
    <ConfigProvider locale={jaJP}>
      <MainLayout>
        <TranslationPanel />
      </MainLayout>
    </ConfigProvider>
  );
};

export default App;
```

### メインレイアウトコンポーネント
```tsx
// src/renderer/components/Layout/MainLayout.tsx
import React from 'react';
import { Layout, Checkbox } from 'antd';
import { useSettingsStore } from '../../stores/settingsStore';
import './MainLayout.css';

const { Header, Content } = Layout;

interface MainLayoutProps {
  children: React.ReactNode;
}

const MainLayout: React.FC<MainLayoutProps> = ({ children }) => {
  const { settings, updateSettings } = useSettingsStore();

  const handleAlwaysOnTopChange = (checked: boolean) => {
    updateSettings({ alwaysOnTop: checked });
    // Electron main processに通知
    window.electronAPI.setAlwaysOnTop(checked);
  };

  return (
    <Layout className="main-layout">
      <Header className="header">
        <div className="header-left">
          <img src="/assets/logo.png" alt="DualDeepL" className="logo" />
        </div>
        <div className="header-right">
          <Checkbox
            checked={settings.alwaysOnTop}
            onChange={(e) => handleAlwaysOnTopChange(e.target.checked)}
            className="always-on-top-checkbox"
          >
            最前面に表示
          </Checkbox>
        </div>
      </Header>
      <Content className="content">
        {children}
      </Content>
    </Layout>
  );
};

export default MainLayout;
```

### 翻訳パネルコンポーネント
```tsx
// src/renderer/components/TranslationPanel/index.tsx
import React, { useEffect, useCallback } from 'react';
import { Row, Col, Divider } from 'antd';
import OriginalTextPanel from './OriginalTextPanel';
import TranslationResultPanel from './TranslationResultPanel';
import { useTranslationStore } from '../../stores/translationStore';
import { useSettingsStore } from '../../stores/settingsStore';
import { useDebounce } from '../../utils/debounce';
import './index.css';

const TranslationPanel: React.FC = () => {
  const { 
    translationState, 
    translateDual, 
    setOriginalText,
    clearResults 
  } = useTranslationStore();
  
  const { settings } = useSettingsStore();

  // デバウンスされた翻訳関数
  const debouncedTranslate = useDebounce((text: string) => {
    if (text.trim()) {
      translateDual(text);
    } else {
      clearResults();
    }
  }, settings.typingDelay);

  const handleOriginalTextChange = useCallback((text: string) => {
    setOriginalText(text);
    debouncedTranslate(text);
  }, [debouncedTranslate, setOriginalText]);

  // クリップボード内容を受信
  useEffect(() => {
    const handleClipboardPaste = (text: string) => {
      handleOriginalTextChange(text);
    };

    window.electronAPI.onClipboardPaste(handleClipboardPaste);
    
    return () => {
      window.electronAPI.removeClipboardPasteListener();
    };
  }, [handleOriginalTextChange]);

  return (
    <div className="translation-panel">
      <Row gutter={[16, 16]}>
        {/* 原文入力パネル */}
        <Col span={24}>
          <OriginalTextPanel
            value={translationState.originalText}
            onChange={handleOriginalTextChange}
            loading={translationState.status === 'translating'}
          />
        </Col>
        
        <Divider />
        
        {/* 第1翻訳パネル */}
        <Col span={24}>
          <TranslationResultPanel
            title="第1翻訳"
            languageIndex={settings.firstLanguageIndex}
            translation={translationState.firstTranslation}
            reverseTranslation={translationState.firstReverseTranslation}
            instruction={settings.firstInstruction}
            onLanguageChange={(index) => 
              useSettingsStore.getState().updateSettings({ firstLanguageIndex: index })
            }
            onInstructionChange={(instruction) =>
              useSettingsStore.getState().updateSettings({ firstInstruction: instruction })
            }
            loading={translationState.status === 'translating'}
          />
        </Col>
        
        <Divider />
        
        {/* 第2翻訳パネル */}
        <Col span={24}>
          <TranslationResultPanel
            title="第2翻訳"
            languageIndex={settings.secondLanguageIndex}
            translation={translationState.secondTranslation}
            reverseTranslation={translationState.secondReverseTranslation}
            instruction={settings.secondInstruction}
            onLanguageChange={(index) =>
              useSettingsStore.getState().updateSettings({ secondLanguageIndex: index })
            }
            onInstructionChange={(instruction) =>
              useSettingsStore.getState().updateSettings({ secondInstruction: instruction })
            }
            loading={translationState.status === 'translating'}
          />
        </Col>
      </Row>
    </div>
  );
};

export default TranslationPanel;
```

### 原文入力パネル
```tsx
// src/renderer/components/TranslationPanel/OriginalTextPanel.tsx
import React from 'react';
import { Card, Select, Input, Spin } from 'antd';
import { SUPPORTED_LANGUAGES } from '../../types/language';
import { useSettingsStore } from '../../stores/settingsStore';

const { TextArea } = Input;

interface OriginalTextPanelProps {
  value: string;
  onChange: (value: string) => void;
  loading: boolean;
}

const OriginalTextPanel: React.FC<OriginalTextPanelProps> = ({
  value,
  onChange,
  loading
}) => {
  const { settings, updateSettings } = useSettingsStore();

  return (
    <Card 
      title={
        <div className="panel-header">
          <span className="panel-title">原文</span>
          <Select
            value={settings.originalLanguageIndex}
            onChange={(index) => updateSettings({ originalLanguageIndex: index })}
            className="language-selector"
            placeholder="言語を選択"
          >
            {SUPPORTED_LANGUAGES.map((lang, index) => (
              <Select.Option key={lang.code} value={index}>
                {lang.display}
              </Select.Option>
            ))}
          </Select>
        </div>
      }
      className="original-text-panel"
    >
      <Spin spinning={loading}>
        <TextArea
          value={value}
          onChange={(e) => onChange(e.target.value)}
          placeholder="翻訳したいテキストを入力してください..."
          rows={6}
          autoFocus
        />
      </Spin>
    </Card>
  );
};

export default OriginalTextPanel;
```

### 翻訳結果パネル
```tsx
// src/renderer/components/TranslationPanel/TranslationResultPanel.tsx
import React, { useState } from 'react';
import { Card, Select, Button, Input, Modal, Spin } from 'antd';
import { SettingOutlined, ArrowDownOutlined } from '@ant-design/icons';
import { SUPPORTED_LANGUAGES } from '../../types/language';

const { TextArea } = Input;

interface TranslationResultPanelProps {
  title: string;
  languageIndex: number;
  translation: string;
  reverseTranslation: string;
  instruction: string;
  onLanguageChange: (index: number) => void;
  onInstructionChange: (instruction: string) => void;
  loading: boolean;
}

const TranslationResultPanel: React.FC<TranslationResultPanelProps> = ({
  title,
  languageIndex,
  translation,
  reverseTranslation,
  instruction,
  onLanguageChange,
  onInstructionChange,
  loading
}) => {
  const [instructionModalVisible, setInstructionModalVisible] = useState(false);
  const [tempInstruction, setTempInstruction] = useState(instruction);

  const handleInstructionSave = () => {
    onInstructionChange(tempInstruction);
    setInstructionModalVisible(false);
  };

  const handleInstructionCancel = () => {
    setTempInstruction(instruction);
    setInstructionModalVisible(false);
  };

  return (
    <Card 
      title={
        <div className="panel-header">
          <span className="panel-title">{title}</span>
          <div className="panel-controls">
            <Select
              value={languageIndex}
              onChange={onLanguageChange}
              className="language-selector"
              placeholder="言語を選択"
            >
              {SUPPORTED_LANGUAGES.map((lang, index) => (
                <Select.Option key={lang.code} value={index}>
                  {lang.display}
                </Select.Option>
              ))}
            </Select>
            <Button
              icon={<SettingOutlined />}
              onClick={() => setInstructionModalVisible(true)}
              type="text"
              title="翻訳指示を設定"
            />
          </div>
        </div>
      }
      className="translation-result-panel"
    >
      <Spin spinning={loading}>
        <div className="translation-content">
          {/* 翻訳結果 */}
          <TextArea
            value={translation}
            readOnly
            rows={4}
            placeholder="翻訳結果がここに表示されます..."
            className="translation-result"
          />
          
          {/* 矢印 */}
          <div className="arrow-container">
            <ArrowDownOutlined className="arrow-icon" />
          </div>
          
          {/* 逆翻訳結果 */}
          <TextArea
            value={reverseTranslation}
            readOnly
            rows={3}
            placeholder="逆翻訳結果がここに表示されます..."
            className="reverse-translation-result"
          />
        </div>
      </Spin>

      {/* 指示設定モーダル */}
      <Modal
        title={`${title} - 翻訳指示設定`}
        open={instructionModalVisible}
        onOk={handleInstructionSave}
        onCancel={handleInstructionCancel}
        okText="保存"
        cancelText="キャンセル"
        width={600}
      >
        <TextArea
          value={tempInstruction}
          onChange={(e) => setTempInstruction(e.target.value)}
          placeholder="翻訳時の指示を入力してください（例: カジュアルな表現で翻訳、専門用語は日本語で併記、など）"
          rows={6}
        />
      </Modal>
    </Card>
  );
};

export default TranslationResultPanel;
```

## Electron Main Process

### メインプロセス
```typescript
// src/main/main.ts
import { app, BrowserWindow, ipcMain, globalShortcut, clipboard } from 'electron';
import * as path from 'path';
import { setupTray } from './tray';
import { setupGlobalShortcuts } from './shortcuts';
import { SettingsManager } from './settings';
import { WindowManager } from './window';

class DualDeepLApp {
  private mainWindow: BrowserWindow | null = null;
  private settingsManager: SettingsManager;
  private windowManager: WindowManager;

  constructor() {
    this.settingsManager = new SettingsManager();
    this.windowManager = new WindowManager();
  }

  async initialize() {
    await app.whenReady();
    
    this.createMainWindow();
    this.setupIPC();
    this.setupGlobalShortcuts();
    this.setupTray();
    
    app.on('window-all-closed', () => {
      // macOS以外では全ウィンドウが閉じられてもアプリを終了しない
      if (process.platform !== 'darwin') {
        // システムトレイに格納
      }
    });

    app.on('activate', () => {
      if (BrowserWindow.getAllWindows().length === 0) {
        this.createMainWindow();
      }
    });
  }

  private createMainWindow() {
    const settings = this.settingsManager.getSettings();
    
    this.mainWindow = this.windowManager.createMainWindow({
      width: settings.windowBounds.width,
      height: settings.windowBounds.height,
      x: settings.windowBounds.x,
      y: settings.windowBounds.y,
      webPreferences: {
        nodeIntegration: false,
        contextIsolation: true,
        preload: path.join(__dirname, 'preload.js')
      }
    });

    // 開発環境でのDevTools
    if (process.env.NODE_ENV === 'development') {
      this.mainWindow.webContents.openDevTools();
    }

    // ウィンドウ閉じるボタンでシステムトレイに格納
    this.mainWindow.on('close', (event) => {
      if (!app.isQuiting) {
        event.preventDefault();
        this.mainWindow?.hide();
      }
    });

    // ウィンドウ位置・サイズ保存
    this.mainWindow.on('resize', () => this.saveWindowState());
    this.mainWindow.on('move', () => this.saveWindowState());
  }

  private setupIPC() {
    // 設定関連
    ipcMain.handle('settings:get', () => {
      return this.settingsManager.getSettings();
    });

    ipcMain.handle('settings:update', (_, settings) => {
      this.settingsManager.updateSettings(settings);
    });

    // ウィンドウ制御
    ipcMain.handle('window:setAlwaysOnTop', (_, flag: boolean) => {
      this.mainWindow?.setAlwaysOnTop(flag);
    });

    ipcMain.handle('window:show', () => {
      this.showMainWindow();
    });

    // クリップボード
    ipcMain.handle('clipboard:readText', () => {
      return clipboard.readText();
    });
  }

  private setupGlobalShortcuts() {
    setupGlobalShortcuts(() => {
      this.showMainWindowWithClipboard();
    });
  }

  private setupTray() {
    setupTray(
      () => this.showMainWindow(),
      () => this.quit()
    );
  }

  private showMainWindow() {
    if (this.mainWindow) {
      if (this.mainWindow.isMinimized()) {
        this.mainWindow.restore();
      }
      this.mainWindow.show();
      this.mainWindow.focus();
    }
  }

  private showMainWindowWithClipboard() {
    this.showMainWindow();
    
    // クリップボード内容をレンダラープロセスに送信
    const clipboardText = clipboard.readText();
    this.mainWindow?.webContents.send('clipboard:paste', clipboardText);
  }

  private saveWindowState() {
    if (this.mainWindow) {
      const bounds = this.mainWindow.getBounds();
      this.settingsManager.updateSettings({
        windowBounds: bounds
      });
    }
  }

  private quit() {
    app.isQuiting = true;
    globalShortcut.unregisterAll();
    app.quit();
  }
}

const dualtransApp = new DualDeepLApp();
dualtransApp.initialize().catch(console.error);
```

### グローバルショートカット
```typescript
// src/main/shortcuts.ts
import { globalShortcut } from 'electron';

let lastCKeyPress = 0;
const DOUBLE_PRESS_THRESHOLD = 500; // ms

export function setupGlobalShortcuts(onDoubleCPress: () => void) {
  // Cキーのグローバルショートカットを登録
  const success = globalShortcut.register('C', () => {
    const now = Date.now();
    
    if (now - lastCKeyPress < DOUBLE_PRESS_THRESHOLD) {
      // ダブルCキー検出
      onDoubleCPress();
      lastCKeyPress = 0; // リセット
    } else {
      lastCKeyPress = now;
    }
  });

  if (!success) {
    console.warn('Failed to register global shortcut for C key');
  }

  return success;
}

export function unregisterGlobalShortcuts() {
  globalShortcut.unregisterAll();
}
```

### システムトレイ
```typescript
// src/main/tray.ts
import { Tray, Menu, nativeImage } from 'electron';
import * as path from 'path';

let tray: Tray | null = null;

export function setupTray(onShow: () => void, onQuit: () => void) {
  const iconPath = path.join(__dirname, '../assets/icons/tray-icon.png');
  const icon = nativeImage.createFromPath(iconPath);
  
  tray = new Tray(icon.resize({ width: 16, height: 16 }));
  
  const contextMenu = Menu.buildFromTemplate([
    {
      label: '表示',
      click: onShow
    },
    {
      type: 'separator'
    },
    {
      label: 'DualDeepLを終了する',
      click: onQuit
    }
  ]);

  tray.setContextMenu(contextMenu);
  tray.setToolTip('DualDeepL - Dual Translation Tool');
  
  // トレイアイコンクリックで表示
  tray.on('click', onShow);
}

export function destroyTray() {
  if (tray) {
    tray.destroy();
    tray = null;
  }
}
```

## 翻訳サービス実装

### 翻訳サービスインターフェース
```typescript
// src/renderer/services/translationService.ts
export interface ITranslationService {
  translateAsync(
    sourceLang: string, 
    targetLang: string, 
    text: string, 
    instruction?: string
  ): Promise<string>;
}

export class TranslationServiceManager {
  constructor(
    private openaiService: OpenAITranslationService,
    private deeplService: DeepLTranslationService
  ) {}

  async translateDual(
    originalText: string,
    sourceLang: string,
    firstLang: string,
    secondLang: string,
    firstInstruction?: string,
    secondInstruction?: string
  ) {
    try {
      // 並列で第1・第2翻訳を実行
      const [firstTranslation, secondTranslation] = await Promise.all([
        this.openaiService.translateAsync(sourceLang, firstLang, originalText, firstInstruction),
        this.openaiService.translateAsync(sourceLang, secondLang, originalText, secondInstruction)
      ]);

      // 並列で逆翻訳を実行
      const [firstReverse, secondReverse] = await Promise.all([
        this.deeplService.translateAsync(firstLang, sourceLang, firstTranslation),
        this.deeplService.translateAsync(secondLang, sourceLang, secondTranslation)
      ]);

      return {
        first: firstTranslation,
        second: secondTranslation,
        firstReverse,
        secondReverse
      };
    } catch (error) {
      throw new TranslationError('Translation failed', error);
    }
  }
}
```

### OpenAI翻訳サービス
```typescript
// src/renderer/services/openaiService.ts
import OpenAI from 'openai';
import { ITranslationService } from './translationService';
import { SUPPORTED_LANGUAGES } from '../types/language';

export class OpenAITranslationService implements ITranslationService {
  private client: OpenAI | null = null;

  constructor(private apiKey: string) {
    if (apiKey) {
      this.client = new OpenAI({ 
        apiKey,
        dangerouslyAllowBrowser: true // Electronではセキュア
      });
    }
  }

  updateApiKey(apiKey: string) {
    this.apiKey = apiKey;
    this.client = apiKey ? new OpenAI({ 
      apiKey,
      dangerouslyAllowBrowser: true 
    }) : null;
  }

  async translateAsync(
    sourceLang: string, 
    targetLang: string, 
    text: string, 
    instruction?: string
  ): Promise<string> {
    if (!this.client) {
      throw new Error('OpenAI APIキーが設定されていません。');
    }

    if (!text.trim()) {
      return '';
    }

    try {
      const sourceLangName = this.getLangName(sourceLang);
      const targetLangName = this.getLangName(targetLang);
      const prompt = this.buildPrompt(sourceLangName, targetLangName, text, instruction);

      const response = await this.client.chat.completions.create({
        model: 'gpt-4o-2024-05-13',
        messages: [{ role: 'user', content: prompt }],
        temperature: 0.3,
        max_tokens: 1000
      });

      return response.choices[0]?.message?.content || '翻訳結果を取得できませんでした。';
    } catch (error) {
      console.error('OpenAI Translation Error:', error);
      throw new Error('OpenAI翻訳でエラーが発生しました。');
    }
  }

  private buildPrompt(
    sourceLangName: string, 
    targetLangName: string, 
    text: string, 
    instruction?: string
  ): string {
    if (!instruction?.trim()) {
      return `以下の文章を、${sourceLangName}から${targetLangName}へ翻訳してください:\n${text}`;
    }

    return `#原文 に書かれた${sourceLangName}の文章を${targetLangName}へ翻訳してください。
翻訳の表記は #表記ルール に書かれた指示に従ってください。

#原文
${text}

#表記ルール 
${instruction}

#出力
`;
  }

  private getLangName(langCode: string): string {
    const lang = SUPPORTED_LANGUAGES.find(l => l.code === langCode);
    return lang?.display || langCode;
  }
}
```

### DeepL翻訳サービス
```typescript
// src/renderer/services/deeplService.ts
import axios from 'axios';
import { ITranslationService } from './translationService';

interface DeepLResponse {
  translations: Array<{
    detected_source_language: string;
    text: string;
  }>;
}

export class DeepLTranslationService implements ITranslationService {
  private readonly apiUrl = 'https://api-free.deepl.com/v2/translate';

  constructor(private apiKey: string) {}

  updateApiKey(apiKey: string) {
    this.apiKey = apiKey;
  }

  async translateAsync(
    sourceLang: string, 
    targetLang: string, 
    text: string
  ): Promise<string> {
    if (!this.apiKey) {
      throw new Error('DeepL APIキーが設定されていません。');
    }

    if (!text.trim()) {
      return '';
    }

    try {
      const params = new URLSearchParams();
      params.append('text', text);
      params.append('source_lang', sourceLang);
      params.append('target_lang', targetLang);

      const response = await axios.post<DeepLResponse>(this.apiUrl, params, {
        headers: {
          'Authorization': `DeepL-Auth-Key ${this.apiKey}`,
          'Content-Type': 'application/x-www-form-urlencoded'
        },
        timeout: 10000
      });

      if (response.data.translations?.length > 0) {
        return response.data.translations[0].text || '翻訳結果が空でした。';
      }

      return '翻訳結果を取得できませんでした。';
    } catch (error) {
      console.error('DeepL Translation Error:', error);
      if (axios.isAxiosError(error)) {
        if (error.response?.status === 401) {
          throw new Error('DeepL APIキーが無効です。');
        } else if (error.response?.status === 429) {
          throw new Error('DeepL API利用制限に達しました。');
        }
      }
      throw new Error('DeepL翻訳でエラーが発生しました。');
    }
  }
}
```

## 状態管理実装

### 翻訳状態管理
```typescript
// src/renderer/stores/translationStore.ts
import { create } from 'zustand';
import { TranslationState, TranslationStatus } from '../types/translation';
import { TranslationServiceManager } from '../services/translationService';
import { OpenAITranslationService } from '../services/openaiService';
import { DeepLTranslationService } from '../services/deeplService';
import { useSettingsStore } from './settingsStore';
import { SUPPORTED_LANGUAGES } from '../types/language';

interface TranslationStore {
  translationState: TranslationState;
  serviceManager: TranslationServiceManager | null;
  
  // Actions
  setOriginalText: (text: string) => void;
  translateDual: (text: string) => Promise<void>;
  clearResults: () => void;
  initializeServices: (openaiKey: string, deeplKey: string) => void;
}

export const useTranslationStore = create<TranslationStore>((set, get) => ({
  translationState: {
    status: TranslationStatus.IDLE,
    originalText: '',
    firstTranslation: '',
    secondTranslation: '',
    firstReverseTranslation: '',
    secondReverseTranslation: ''
  },
  serviceManager: null,

  setOriginalText: (text: string) => {
    set(state => ({
      translationState: {
        ...state.translationState,
        originalText: text
      }
    }));
  },

  translateDual: async (text: string) => {
    const { serviceManager } = get();
    const settings = useSettingsStore.getState().settings;
    
    if (!serviceManager) {
      console.error('Translation services not initialized');
      return;
    }

    set(state => ({
      translationState: {
        ...state.translationState,
        status: TranslationStatus.TRANSLATING,
        error: undefined
      }
    }));

    try {
      const sourceLang = SUPPORTED_LANGUAGES[settings.originalLanguageIndex]?.code;
      const firstLang = SUPPORTED_LANGUAGES[settings.firstLanguageIndex]?.code;
      const secondLang = SUPPORTED_LANGUAGES[settings.secondLanguageIndex]?.code;

      if (!sourceLang || !firstLang || !secondLang) {
        throw new Error('言語設定が不正です。');
      }

      const result = await serviceManager.translateDual(
        text,
        sourceLang,
        firstLang,
        secondLang,
        settings.firstInstruction,
        settings.secondInstruction
      );

      set(state => ({
        translationState: {
          ...state.translationState,
          status: TranslationStatus.SUCCESS,
          firstTranslation: result.first,
          secondTranslation: result.second,
          firstReverseTranslation: result.firstReverse,
          secondReverseTranslation: result.secondReverse
        }
      }));
    } catch (error) {
      const errorMessage = error instanceof Error ? error.message : '翻訳中にエラーが発生しました。';
      
      set(state => ({
        translationState: {
          ...state.translationState,
          status: TranslationStatus.ERROR,
          error: errorMessage
        }
      }));
    }
  },

  clearResults: () => {
    set(state => ({
      translationState: {
        ...state.translationState,
        status: TranslationStatus.IDLE,
        firstTranslation: '',
        secondTranslation: '',
        firstReverseTranslation: '',
        secondReverseTranslation: '',
        error: undefined
      }
    }));
  },

  initializeServices: (openaiKey: string, deeplKey: string) => {
    const openaiService = new OpenAITranslationService(openaiKey);
    const deeplService = new DeepLTranslationService(deeplKey);
    const serviceManager = new TranslationServiceManager(openaiService, deeplService);
    
    set({ serviceManager });
  }
}));
```

### 設定状態管理
```typescript
// src/renderer/stores/settingsStore.ts
import { create } from 'zustand';
import { AppSettings, DEFAULT_SETTINGS } from '../types/settings';

interface SettingsStore {
  settings: AppSettings;
  
  // Actions
  loadSettings: () => Promise<void>;
  updateSettings: (partial: Partial<AppSettings>) => Promise<void>;
  validateApiKeys: () => boolean;
}

export const useSettingsStore = create<SettingsStore>((set, get) => ({
  settings: DEFAULT_SETTINGS,

  loadSettings: async () => {
    try {
      const savedSettings = await window.electronAPI.getSettings();
      set({ settings: { ...DEFAULT_SETTINGS, ...savedSettings } });
    } catch (error) {
      console.error('Failed to load settings:', error);
    }
  },

  updateSettings: async (partial: Partial<AppSettings>) => {
    const { settings } = get();
    const newSettings = { ...settings, ...partial };
    
    try {
      await window.electronAPI.updateSettings(newSettings);
      set({ settings: newSettings });
      
      // API キーが更新された場合、翻訳サービスを再初期化
      if (partial.openaiApiKey || partial.deeplApiKey) {
        const { initializeServices } = useTranslationStore.getState();
        initializeServices(newSettings.openaiApiKey, newSettings.deeplApiKey);
      }
    } catch (error) {
      console.error('Failed to update settings:', error);
    }
  },

  validateApiKeys: () => {
    const { settings } = get();
    const hasOpenAIKey = !!settings.openaiApiKey?.trim();
    const hasDeepLKey = !!settings.deeplApiKey?.trim();
    
    if (!hasOpenAIKey && !hasDeepLKey) {
      // エラー表示ロジック
      return false;
    }
    
    return true;
  }
}));
```

このImplementation Guideにより、実際のコード実装の詳細が提供されます。MIGRATION_SPECIFICATION.mdと合わせることで、完全な移行ガイドとなります。