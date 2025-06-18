# DualDeepL AI Assistant Quick Reference

このドキュメントは、ChatGPTやClaudeなどの生成AIがDualDeepLの移行作業を効率的に進めるためのクイックリファレンスです。

## 📋 プロジェクト概要

**現在**: C# Windows Forms デスクトップアプリケーション  
**移行先**: Electron + TypeScript + React  
**主機能**: デュアル翻訳（1つの原文を2つの言語に同時翻訳）

## 🎯 必須機能チェックリスト

### 翻訳機能
- [ ] OpenAI GPT-4による翻訳（カスタム指示対応）
- [ ] DeepL APIによる翻訳（主に逆翻訳用）
- [ ] 1秒のタイピング停止後の自動翻訳
- [ ] 並列翻訳処理（第1・第2言語同時実行）
- [ ] 逆翻訳機能（精度確認用）

### UI/UX
- [ ] 3パネル構成（原文・第1翻訳・第2翻訳）
- [ ] 言語選択コンボボックス（30言語対応）
- [ ] カスタム翻訳指示設定ダイアログ
- [ ] 「最前面に表示」オプション
- [ ] ダーク系テーマ

### システム統合
- [ ] グローバルホットキー（Cキー2回押し）
- [ ] システムトレイ統合
- [ ] クリップボード自動貼り付け
- [ ] 設定永続化
- [ ] シングルインスタンス制御

## 🔧 技術スタック

```typescript
"dependencies": {
  "electron": "^27.0.0",
  "react": "^18.2.0",
  "typescript": "^5.0.0",
  "zustand": "^4.4.0",
  "antd": "^5.12.0",
  "axios": "^1.6.0",
  "openai": "^4.20.0"
}
```

## 📁 プロジェクト構造

```
src/
├── main/                    # Electron Main Process
│   ├── main.ts             # アプリケーションエントリーポイント
│   ├── tray.ts             # システムトレイ管理
│   ├── shortcuts.ts        # グローバルホットキー
│   └── settings.ts         # 設定管理
├── renderer/               # React Frontend
│   ├── components/
│   │   ├── TranslationPanel/
│   │   ├── LanguageSelector/
│   │   └── InstructionDialog/
│   ├── services/           # 翻訳サービス
│   ├── stores/            # Zustand状態管理
│   └── types/             # TypeScript型定義
└── shared/                # 共通定義
```

## 🌐 API統合仕様

### OpenAI翻訳
```typescript
// モデル: gpt-4o-2024-05-13
// 基本プロンプト
`以下の文章を、${sourceLang}から${targetLang}へ翻訳してください:\n${text}`

// カスタム指示付きプロンプト
`#原文 に書かれた${sourceLang}の文章を${targetLang}へ翻訳してください。
翻訳の表記は #表記ルール に書かれた指示に従ってください。

#原文
${text}

#表記ルール 
${instruction}

#出力`
```

### DeepL翻訳
```typescript
// エンドポイント: https://api-free.deepl.com/v2/translate
// 主に逆翻訳で使用
const params = {
  text: string,
  source_lang: string,
  target_lang: string
}
```

## 🎨 UI コンポーネント構成

### レイアウト階層
```
MainLayout
├── Header (ロゴ + 最前面チェックボックス)
└── TranslationPanel
    ├── OriginalTextPanel (原文入力)
    ├── TranslationResultPanel (第1翻訳)
    └── TranslationResultPanel (第2翻訳)
```

### 主要コンポーネント
1. **OriginalTextPanel**: 原文入力＋言語選択
2. **TranslationResultPanel**: 翻訳結果＋逆翻訳＋指示設定
3. **LanguageSelector**: 30言語対応ドロップダウン
4. **InstructionDialog**: カスタム翻訳指示設定

## ⚡ 主要処理フロー

### 翻訳フロー
```
1. ユーザー入力 → タイマーリセット
2. 1秒停止 → 翻訳開始
3. 並列実行:
   - 原文 → 第1言語 (OpenAI)
   - 原文 → 第2言語 (OpenAI)
4. 逆翻訳実行:
   - 第1翻訳 → 原文 (DeepL)
   - 第2翻訳 → 原文 (DeepL)
5. 結果表示
```

### ホットキーフロー
```
1. グローバル'C'キー検出
2. 500ms以内の2回目検出
3. ウィンドウ前面表示
4. クリップボード内容自動入力
5. 翻訳開始
```

## 🔧 実装優先順位

### Phase 1: 基盤構築
1. Electronプロジェクト初期化
2. React + TypeScript設定
3. 基本レイアウト作成

### Phase 2: コア機能
1. 翻訳サービス実装
2. UI コンポーネント構築
3. 状態管理（Zustand）

### Phase 3: システム統合
1. Electron Main Process
2. IPC通信
3. グローバルホットキー

### Phase 4: 高度機能
1. システムトレイ
2. 設定永続化
3. エラーハンドリング

## 🚨 重要な実装ポイント

### セキュリティ
```typescript
// APIキーをRenderer Processで露出しない
// Main Processで管理し、IPCで通信
webPreferences: {
  nodeIntegration: false,
  contextIsolation: true,
  preload: path.join(__dirname, 'preload.js')
}
```

### パフォーマンス
```typescript
// デバウンス処理で連続API呼び出し防止
const debouncedTranslate = useDebounce((text: string) => {
  translateDual(text);
}, 1000);

// 並列処理で翻訳速度向上
const [first, second] = await Promise.all([
  translateFirst(), 
  translateSecond()
]);
```

### エラーハンドリング
```typescript
// ユーザーフレンドリーなエラーメッセージ
const errorMessages = {
  Translation: "翻訳に失敗しました。APIキーとネットワークを確認してください。",
  Settings: "設定の保存に失敗しました。",
  Clipboard: "クリップボードの読み取りに失敗しました。"
};
```

## 📚 参考資料

1. **MIGRATION_SPECIFICATION.md**: 完全な仕様書
2. **TECHNICAL_IMPLEMENTATION_GUIDE.md**: 詳細実装ガイド
3. **現在のソースコード**: `/DualDeepL/` ディレクトリ

## 🔍 よくある質問

**Q: どの翻訳サービスを第1・第2翻訳に使うべきか？**  
A: 両方ともOpenAI GPT-4を使用。DeepLは逆翻訳専用。

**Q: システムトレイの動作は？**  
A: ウィンドウ閉じるボタンで完全終了せず、トレイに格納。

**Q: グローバルホットキーの仕様は？**  
A: 'C'キーを500ms以内に2回押下で起動。

**Q: 設定ファイルの保存場所は？**  
A: Electronの`app.getPath('userData')`ディレクトリ。

**Q: 言語コードの対応は？**  
A: 30言語対応、コードとして"EN", "JA", "ZH"等を使用。

---

このクイックリファレンスを活用して、効率的にDualDeepLの移行作業を進めてください。詳細な実装については、関連ドキュメントを参照してください。