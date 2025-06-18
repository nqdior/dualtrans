# DualDeepL Migration Specification: Windows Forms to Electron + TypeScript + React

このドキュメントは、DualDeepLアプリケーションをWindows FormsからElectron + TypeScript + Reactへ移行するための包括的な仕様書です。ChatGPTやClaudeなどの生成AIにとって必要なすべての情報が含まれています。

## 目次
1. [アプリケーション概要](#アプリケーション概要)
2. [コア機能仕様](#コア機能仕様)
3. [UI/UXデザイン仕様](#uiuxデザイン仕様)
4. [技術アーキテクチャ](#技術アーキテクチャ)
5. [API統合仕様](#api統合仕様)
6. [ユーザーインタラクション仕様](#ユーザーインタラクション仕様)
7. [設定・構成管理](#設定構成管理)
8. [エラーハンドリング](#エラーハンドリング)
9. [移行ガイドライン](#移行ガイドライン)

## アプリケーション概要

### 目的
DualDeepLは、1つの原文を2つの異なる言語に同時翻訳するデュアル翻訳デスクトップアプリケーションです。

### 主要価値提案
- **並列翻訳**: 1つのテキストを2つの言語に同時翻訳
- **AI翻訳統合**: OpenAI GPT-4とDeepL APIの両方をサポート
- **リアルタイム処理**: タイピング停止後の自動翻訳
- **グローバルアクセス**: システム全体からのホットキーアクセス
- **逆翻訳機能**: 翻訳結果の精度確認のための逆翻訳

### ターゲットユーザー
- 多言語コンテンツ作成者
- 翻訳者・言語学習者
- 国際的なコミュニケーションを行う専門家

## コア機能仕様

### 1. デュアル翻訳エンジン

#### 1.1 翻訳フロー
```
原文 (Source Language)
  ├── 第1翻訳 (First Target Language) → 逆翻訳 (First → Source)
  └── 第2翻訳 (Second Target Language) → 逆翻訳 (Second → Source)
```

#### 1.2 翻訳サービス
- **OpenAI Translation Service**
  - モデル: GPT-4o-2024-05-13
  - カスタム指示対応
  - プロンプトテンプレート機能
- **DeepL Translation Service**
  - REST API統合
  - 高精度翻訳
  - 主に逆翻訳に使用

#### 1.3 翻訳トリガー
- **自動翻訳**: 1秒間のタイピング停止後
- **手動翻訳**: フォーカス離脱時（現在は無効化）
- **クリップボード翻訳**: グローバルホットキー経由

### 2. 言語サポート

#### 2.1 サポート言語リスト
```typescript
interface Language {
  code: string;
  display: string;
}

const supportedLanguages: Language[] = [
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

### 3. グローバルホットキー機能

#### 3.1 ホットキー仕様
- **キー組み合わせ**: 'C'キーを500ms以内に2回押下
- **動作**: アプリケーション表示 + クリップボード内容の自動入力
- **技術実装**: Windows Hook API (LowLevel Keyboard Hook)

#### 3.2 動作フロー
```
1. グローバル'C'キーイベント検出
2. 前回'C'押下から500ms以内かチェック
3. 条件満足時:
   - アプリケーションウィンドウを前面表示
   - クリップボード内容を原文テキストボックスに設定
   - 自動翻訳開始
```

### 4. システムトレイ統合

#### 4.1 システムトレイ機能
- **最小化動作**: ウィンドウ閉じるボタンで完全終了せず、システムトレイに格納
- **トレイアイコン**: DeepLロゴアイコン使用
- **コンテキストメニュー**: "DualDeepLを終了する"オプション
- **復帰方法**: トレイアイコンクリックでウィンドウ復帰

## UI/UXデザイン仕様

### 1. レイアウト構造

#### 1.1 全体レイアウト
```
┌─────────────────────────────────────────────────────┐
│ [ロゴ]                              [最前面に表示] │ ← ヘッダーパネル
├─────────────────────────────────────────────────────┤
│ 原文 [言語選択▼]                                  │
│ ┌─────────────────────────────────────────────────┐ │
│ │ 原文入力エリア                                  │ │
│ └─────────────────────────────────────────────────┘ │
├─────────────────────────────────────────────────────┤
│ 第1翻訳 [言語選択▼] [指示設定]                    │
│ ┌─────────────────────────────────────────────────┐ │
│ │ 第1翻訳結果表示                                │ │
│ └─────────────────────────────────────────────────┘ │
│ ↓                                                 │
│ ┌─────────────────────────────────────────────────┐ │
│ │ 第1逆翻訳結果                                  │ │
│ └─────────────────────────────────────────────────┘ │
├─────────────────────────────────────────────────────┤
│ 第2翻訳 [言語選択▼] [指示設定]                    │
│ ┌─────────────────────────────────────────────────┐ │
│ │ 第2翻訳結果表示                                │ │
│ └─────────────────────────────────────────────────┘ │
│ ↓                                                 │
│ ┌─────────────────────────────────────────────────┐ │
│ │ 第2逆翻訳結果                                  │ │
│ └─────────────────────────────────────────────────┘ │
└─────────────────────────────────────────────────────┘
```

#### 1.2 コンポーネント詳細

**ヘッダーパネル (panel_top)**
- 背景色: ダーク系
- ロゴ画像: 左端配置、ストレッチ表示
- チェックボックス: "最前面に表示"、右端配置、白文字

**原文セクション (Original Text)**
- ラベル: "原文"、白文字、太字
- 言語選択: ComboBox、選択値を設定に保存
- テキストエリア: RichTextBox、フォーカス時アクティブ

**翻訳セクション (First/Second Translation)**
- ラベル: "第1翻訳"/"第2翻訳"、白文字、太字
- 言語選択: ComboBox、選択値を設定に保存
- 指示設定ボタン: カスタム翻訳指示の設定ダイアログ表示
- 翻訳結果: RichTextBox、読み取り専用
- 矢印ラベル: "↓" 視覚的な流れ表示
- 逆翻訳結果: RichTextBox、読み取り専用

### 2. スタイリング仕様

#### 2.1 フォント
- メインフォント: "BIZ UDゴシック"
- サイズ: 11.25F (通常), 12F (ラベル太字)
- 色: 白/ライトグレー (ダーク背景用)

#### 2.2 カラーパレット
- 背景: ダーク系 (具体的な色値は現在のテーマから抽出)
- テキスト: 白/ライトグレー
- アクセント: システムカラー使用

#### 2.3 レスポンシブ動作
- ウィンドウサイズ: 固定サイズ推奨
- テキストエリア: ウィンドウサイズに応じて調整
- レイアウト: TableLayoutPanel使用で柔軟な配置

### 3. インタラクションデザイン

#### 3.1 フィードバック
- 翻訳中: カーソル変更 (WaitCursor)
- エラー時: ユーザーフレンドリーなメッセージボックス
- 成功時: 結果テキストボックスに即座に反映

#### 3.2 ユーザビリティ
- タブ順序: 原文 → 第1翻訳 → 第2翻訳
- ショートカット: ホットキー以外は現在未実装
- アクセシビリティ: 標準Windows Formsアクセシビリティ

## 技術アーキテクチャ

### 1. 現在のアーキテクチャ

#### 1.1 レイヤー構造
```
Presentation Layer (UI)
├── MainForm.cs (メイン翻訳インターフェース)
├── InstructionForm.cs (指示設定ダイアログ)
└── Program.cs (アプリケーションエントリーポイント)

Business Logic Layer
├── Services/
│   ├── ITranslationService.cs (翻訳サービスインターフェース)
│   ├── OpenAITranslationService.cs (OpenAI統合)
│   └── DeepLTranslationService.cs (DeepL統合)
├── Models/
│   ├── LanguageManager.cs (言語管理)
│   └── ResponseModels.cs (API応答モデル)
└── Utils/
    ├── ErrorHandler.cs (エラーハンドリング)
    └── GlbUtil.cs (ユーティリティ)

Infrastructure Layer
├── Properties/ (設定管理)
├── Resources/ (リソース管理)
└── External APIs (OpenAI, DeepL)
```

#### 1.2 依存関係
```csharp
// NuGet Packages
- Newtonsoft.Json (13.0.3)
- OpenAI (1.7.2)

// Framework
- .NET 6.0 Windows
- Windows Forms
```

### 2. 移行後のElectronアーキテクチャ提案

#### 2.1 技術スタック
```typescript
Frontend Framework: React 18+
Type System: TypeScript 5+
Desktop Framework: Electron
Build Tool: Vite
State Management: Zustand または Redux Toolkit
UI Components: Ant Design または Material-UI
HTTP Client: Axios
```

#### 2.2 プロジェクト構造提案
```
src/
├── main/ (Electron Main Process)
│   ├── main.ts
│   ├── tray.ts
│   ├── globalShortcuts.ts
│   └── windowManager.ts
├── renderer/ (React Frontend)
│   ├── components/
│   │   ├── TranslationPanel/
│   │   ├── LanguageSelector/
│   │   ├── InstructionDialog/
│   │   └── Layout/
│   ├── services/
│   │   ├── translationService.ts
│   │   ├── openaiService.ts
│   │   └── deeplService.ts
│   ├── stores/
│   │   ├── translationStore.ts
│   │   └── settingsStore.ts
│   ├── types/
│   │   ├── translation.ts
│   │   └── language.ts
│   └── utils/
│       ├── errorHandler.ts
│       └── storage.ts
└── shared/
    ├── constants/
    └── types/
```

## API統合仕様

### 1. OpenAI Translation Service

#### 1.1 API設定
```typescript
interface OpenAIConfig {
  apiKey: string;
  model: "gpt-4o-2024-05-13";
  baseURL?: string;
}
```

#### 1.2 プロンプトテンプレート
```typescript
// 基本翻訳プロンプト
const basicPrompt = (sourceLang: string, targetLang: string, text: string) => 
  `以下の文章を、${sourceLang}から${targetLang}へ翻訳してください:\n${text}`;

// カスタム指示付きプロンプト  
const instructionPrompt = (sourceLang: string, targetLang: string, text: string, instruction: string) => 
  `#原文 に書かれた${sourceLang}の文章を${targetLang}へ翻訳してください。
翻訳の表記は #表記ルール に書かれた指示に従ってください。

#原文
${text}

#表記ルール 
${instruction}

#出力
`;
```

#### 1.3 エラーハンドリング
```typescript
interface TranslationError {
  type: 'API_ERROR' | 'NETWORK_ERROR' | 'RATE_LIMIT' | 'INVALID_KEY';
  message: string;
  originalError?: Error;
}
```

### 2. DeepL Translation Service

#### 2.1 API設定
```typescript
interface DeepLConfig {
  apiKey: string;
  apiUrl: "https://api-free.deepl.com/v2/translate";
  headers: {
    "Authorization": `DeepL-Auth-Key ${apiKey}`;
    "Content-Type": "application/x-www-form-urlencoded";
  };
}
```

#### 2.2 リクエスト形式
```typescript
interface DeepLRequest {
  text: string;
  source_lang: string;
  target_lang: string;
}

interface DeepLResponse {
  translations: Array<{
    detected_source_language: string;
    text: string;
  }>;
}
```

### 3. 統合翻訳サービス

#### 3.1 サービスインターフェース
```typescript
interface ITranslationService {
  translateAsync(
    sourceLang: string, 
    targetLang: string, 
    text: string, 
    instruction?: string
  ): Promise<string>;
}
```

#### 3.2 サービス実装パターン
```typescript
class TranslationServiceManager {
  private openaiService: OpenAITranslationService;
  private deeplService: DeepLTranslationService;
  
  async translateDual(
    sourceLang: string,
    firstLang: string, 
    secondLang: string,
    text: string,
    firstInstruction?: string,
    secondInstruction?: string
  ): Promise<{
    first: string;
    second: string;
    reverseFirst?: string;
    reverseSecond?: string;
  }>;
}
```

## ユーザーインタラクション仕様

### 1. 翻訳フロー

#### 1.1 自動翻訳フロー
```
1. ユーザーが原文テキストボックスに入力
2. TextChangedイベント発生
3. タイピングタイマーリセット (1秒)
4. 1秒間入力がない場合
5. 翻訳プロセス開始
   a. 原文 → 第1言語 (OpenAI + カスタム指示)
   b. 原文 → 第2言語 (OpenAI + カスタム指示)
   c. 第1翻訳 → 原文 (DeepL) [並行実行]
   d. 第2翻訳 → 原文 (DeepL) [並行実行]
6. 結果をそれぞれのテキストボックスに表示
```

#### 1.2 ホットキーフロー
```
1. グローバル'C'キー検出
2. 500ms以内の2回目'C'キー検出
3. アプリケーション前面表示
   - Show()
   - WindowState = Normal
   - TopMost = true → false
4. クリップボード内容取得
5. 原文テキストボックスに設定
6. 自動翻訳開始
```

### 2. 設定管理フロー

#### 2.1 言語選択
```typescript
interface LanguageSettings {
  originalLanguage: number; // ComboBoxのSelectedIndex
  firstLanguage: number;
  secondLanguage: number;
}

// 変更時の動作
onLanguageChange = (type: 'original' | 'first' | 'second', index: number) => {
  // 設定保存
  saveSettings({ [type + 'Language']: index });
  // 必要に応じて再翻訳
  if (hasOriginalText) {
    triggerTranslation();
  }
};
```

#### 2.2 カスタム指示設定
```typescript
interface InstructionSettings {
  instruct1: string; // 第1翻訳用指示
  instruct2: string; // 第2翻訳用指示
}

// 指示設定ダイアログ
const InstructionDialog = ({ 
  instructionKey, 
  currentValue, 
  onSave 
}: {
  instructionKey: 'instruct1' | 'instruct2';
  currentValue: string;
  onSave: (value: string) => void;
}) => {
  // ダイアログ実装
};
```

### 3. エラーハンドリングフロー

#### 3.1 エラー分類とメッセージ
```typescript
const errorMessages = {
  Translation: "翻訳に失敗しました。APIキーの設定とネットワーク接続を確認してください。",
  Settings: "設定の保存に失敗しました。",
  Clipboard: "クリップボードの読み取りに失敗しました。",
  Default: (operation: string) => `操作「${operation}」でエラーが発生しました。しばらく時間を置いてから再試行してください。`
};
```

#### 3.2 API キー検証
```typescript
const validateApiKeys = (): boolean => {
  const hasOpenAIKey = !!(settings.apiKey?.trim());
  const hasDeepLKey = !!(settings.deepLKey?.trim());
  
  if (!hasOpenAIKey && !hasDeepLKey) {
    showError("OpenAI または DeepL のAPIキーが設定されていません。設定を確認してください。");
    return false;
  }
  
  return true;
};
```

## 設定・構成管理

### 1. 設定項目

#### 1.1 翻訳設定
```typescript
interface TranslationSettings {
  // API設定
  apiKey: string;        // OpenAI APIキー
  deepLKey: string;      // DeepL APIキー
  
  // 言語設定
  originalLanguage: number;  // 原文言語のインデックス
  firstLanguage: number;     // 第1翻訳言語のインデックス  
  secondLanguage: number;    // 第2翻訳言語のインデックス
  
  // カスタム指示
  instruct1: string;     // 第1翻訳用指示
  instruct2: string;     // 第2翻訳用指示
}
```

#### 1.2 UI設定
```typescript
interface UISettings {
  // ウィンドウ設定
  windowWidth: number;
  windowHeight: number;
  windowX: number;
  windowY: number;
  
  // 表示設定
  alwaysOnTop: boolean;
  
  // 動作設定
  typingDelay: number;   // タイピング停止判定時間(ms)
}
```

### 2. 設定永続化

#### 2.1 Electronでの実装
```typescript
// main プロセスでの設定管理
import { app } from 'electron';
import * as path from 'path';
import * as fs from 'fs';

class SettingsManager {
  private settingsPath: string;
  
  constructor() {
    this.settingsPath = path.join(app.getPath('userData'), 'settings.json');
  }
  
  load<T>(): T {
    try {
      const data = fs.readFileSync(this.settingsPath, 'utf8');
      return JSON.parse(data);
    } catch {
      return {} as T;
    }
  }
  
  save<T>(settings: T): void {
    fs.writeFileSync(this.settingsPath, JSON.stringify(settings, null, 2));
  }
}
```

## エラーハンドリング

### 1. エラー分類

#### 1.1 翻訳エラー
```typescript
enum TranslationErrorType {
  API_KEY_MISSING = 'API_KEY_MISSING',
  API_KEY_INVALID = 'API_KEY_INVALID', 
  NETWORK_ERROR = 'NETWORK_ERROR',
  RATE_LIMIT = 'RATE_LIMIT',
  SERVICE_UNAVAILABLE = 'SERVICE_UNAVAILABLE',
  INVALID_LANGUAGE = 'INVALID_LANGUAGE',
  TEXT_TOO_LONG = 'TEXT_TOO_LONG'
}
```

#### 1.2 システムエラー
```typescript
enum SystemErrorType {
  CLIPBOARD_ACCESS = 'CLIPBOARD_ACCESS',
  SETTINGS_SAVE = 'SETTINGS_SAVE',
  SETTINGS_LOAD = 'SETTINGS_LOAD',
  WINDOW_MANAGEMENT = 'WINDOW_MANAGEMENT',
  HOTKEY_REGISTRATION = 'HOTKEY_REGISTRATION'
}
```

### 2. エラー表示パターン

#### 2.1 ユーザーフレンドリーメッセージ
```typescript
const getErrorMessage = (errorType: string, context?: string): string => {
  const messages = {
    [TranslationErrorType.API_KEY_MISSING]: "APIキーが設定されていません。設定画面で確認してください。",
    [TranslationErrorType.NETWORK_ERROR]: "ネットワークエラーが発生しました。接続を確認してください。",
    [TranslationErrorType.RATE_LIMIT]: "API利用制限に達しました。しばらく時間をおいてから再試行してください。",
    [SystemErrorType.CLIPBOARD_ACCESS]: "クリップボードにアクセスできませんでした。",
    [SystemErrorType.SETTINGS_SAVE]: "設定の保存に失敗しました。"
  };
  
  return messages[errorType] || `エラーが発生しました: ${context}`;
};
```

## 移行ガイドライン

### 1. 段階的移行計画

#### Phase 1: プロジェクト基盤構築
```bash
# Electronプロジェクト初期化
npm create electron-app@latest dualtrans-electron -- --template=typescript-webpack

# 必要な依存関係追加
npm install react react-dom @types/react @types/react-dom
npm install axios zustand
npm install antd # または @mui/material

# 開発用依存関係
npm install -D @types/electron vite
```

#### Phase 2: コア機能移植
1. **翻訳サービス移植**
   - ITranslationService インターフェース
   - OpenAITranslationService
   - DeepLTranslationService

2. **UI コンポーネント構築**
   - TranslationPanel
   - LanguageSelector  
   - TextAreaComponent

3. **状態管理実装**
   - Translation Store
   - Settings Store

#### Phase 3: Electron統合
1. **Main Process機能**
   - System Tray
   - Global Shortcuts
   - Window Management

2. **IPC通信**
   - Renderer ↔ Main Process
   - Settings Management
   - Clipboard Access

#### Phase 4: 高度な機能
1. **自動翻訳タイマー**
2. **エラーハンドリング**
3. **設定永続化**
4. **パフォーマンス最適化**

### 2. 主要課題と解決策

#### 2.1 Global Shortcuts
**課題**: Windows Hook APIの代替
**解決策**: Electronの`globalShortcut` API使用
```typescript
import { globalShortcut } from 'electron';

// ダブルCキー検出のロジック実装
let lastCPress = 0;
globalShortcut.register('C', () => {
  const now = Date.now();
  if (now - lastCPress < 500) {
    // ダブルCキー検出
    showWindowAndPasteClipboard();
  }
  lastCPress = now;
});
```

#### 2.2 System Tray
**課題**: Windows Forms NotifyIconの代替
**解決策**: Electronの`Tray` API使用
```typescript
import { Tray, Menu } from 'electron';

const createTray = () => {
  const tray = new Tray('assets/icon.png');
  tray.setContextMenu(Menu.buildFromTemplate([
    {
      label: 'DualDeepLを終了する',
      click: () => app.quit()
    }
  ]));
  
  tray.on('click', () => {
    mainWindow.show();
  });
};
```

#### 2.3 設定管理
**課題**: Windows Forms Settings.Defaultの代替
**解決策**: electron-storeまたはカスタム実装
```typescript
import Store from 'electron-store';

interface AppSettings {
  apiKey: string;
  deepLKey: string;
  // ... その他の設定
}

const store = new Store<AppSettings>({
  defaults: {
    originalLanguage: 0,
    firstLanguage: 1,
    secondLanguage: 2
  }
});
```

### 3. テスト戦略

#### 3.1 Unit Tests
```typescript
// Translation Service Tests
describe('OpenAITranslationService', () => {
  test('should translate text correctly', async () => {
    // テスト実装
  });
  
  test('should handle API errors gracefully', async () => {
    // エラーハンドリングテスト
  });
});
```

#### 3.2 Integration Tests
```typescript
// End-to-End Tests
describe('Translation Flow', () => {
  test('should perform dual translation', async () => {
    // E2Eテスト実装
  });
});
```

### 4. パフォーマンス考慮事項

#### 4.1 翻訳リクエスト最適化
- デバウンス処理の適切な実装
- 並列翻訳リクエストの管理
- API レート制限への対応

#### 4.2 UI レスポンシブネス
- 非同期処理によるUI ブロック防止
- 翻訳進行状況の視覚的フィードバック
- エラー時の適切な状態復旧

### 5. セキュリティ考慮事項

#### 5.1 API Key管理
- Renderer ProcessでのAPI Key露出防止
- Main Processでの安全な保存
- 設定ファイルの暗号化検討

#### 5.2 External API通信
- HTTPS通信の強制
- 証明書検証の実装
- タイムアウト設定の適切な配置

## 結論

この仕様書は、DualDeepLアプリケーションの完全な移行に必要なすべての情報を提供しています。生成AIアシスタントは、この文書を参考にして段階的に移行を進めることができます。

重要なポイント:
1. **機能の完全性**: 現在のすべての機能を維持
2. **ユーザー体験**: UI/UXの一貫性を保持
3. **技術的品質**: TypeScriptによる型安全性とテスタビリティ
4. **拡張性**: 将来の機能追加への対応
5. **保守性**: クリーンなアーキテクチャとドキュメント

この仕様に従って実装することで、元のWindows Formsアプリケーションと同等以上の品質とユーザー体験を持つElectronアプリケーションを構築できます。