using System.Drawing;

namespace DualDeepL.Utils
{
    public static class ModernTheme
    {
        // Modern color palette as requested in the issue
        public static class Colors
        {
            // Dark theme colors (default)
            public static readonly Color DarkBackground = Color.FromArgb(30, 30, 46);     // #1e1e2e
            public static readonly Color CardBackground = Color.FromArgb(49, 50, 68);     // #313244 (slightly lighter for cards)
            public static readonly Color InputBackground = Color.FromArgb(56, 58, 80);    // #383a50 (for text inputs)
            
            // Light theme colors (for future theme switching)
            public static readonly Color LightBackground = Color.FromArgb(248, 250, 252); // #f8fafc
            public static readonly Color LightCardBackground = Color.FromArgb(255, 255, 255); // #ffffff
            public static readonly Color LightInputBackground = Color.FromArgb(241, 245, 249); // #f1f5f9
            
            // Main colors (work for both themes)
            public static readonly Color IndigoMain = Color.FromArgb(79, 70, 229);        // #4f46e5
            public static readonly Color IndigoHover = Color.FromArgb(99, 90, 249);       // #6366f1
            public static readonly Color EmeraldAccent = Color.FromArgb(16, 185, 129);    // #10b981
            public static readonly Color EmeraldHover = Color.FromArgb(20, 220, 160);     // #14dca0
            
            // Text colors (dark theme)
            public static readonly Color PrimaryText = Color.FromArgb(241, 245, 249);     // #f1f5f9 (slate-100)
            public static readonly Color SecondaryText = Color.FromArgb(148, 163, 184);   // #94a3b8 (slate-400)
            public static readonly Color MutedText = Color.FromArgb(100, 116, 139);       // #64748b (slate-500)
            
            // Text colors (light theme)
            public static readonly Color LightPrimaryText = Color.FromArgb(15, 23, 42);   // #0f172a (slate-900)
            public static readonly Color LightSecondaryText = Color.FromArgb(71, 85, 105); // #475569 (slate-600)
            public static readonly Color LightMutedText = Color.FromArgb(100, 116, 139);  // #64748b (slate-500)
            
            // Border and separator colors
            public static readonly Color Border = Color.FromArgb(71, 85, 105);            // #475569 (slate-600)
            public static readonly Color BorderLight = Color.FromArgb(100, 116, 139);     // #64748b (slate-500)
            
            // Status colors
            public static readonly Color Success = Color.FromArgb(34, 197, 94);           // #22c55e
            public static readonly Color Warning = Color.FromArgb(251, 191, 36);          // #fbbf24
            public static readonly Color Error = Color.FromArgb(239, 68, 68);             // #ef4444
        }
        
        // Modern fonts
        public static class Fonts
        {
            public static readonly Font PrimaryFont = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            public static readonly Font HeaderFont = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            public static readonly Font ButtonFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            public static readonly Font SmallFont = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            
            // Fallback to system fonts if modern fonts aren't available
            public static readonly Font FallbackPrimaryFont = new Font("Yu Gothic UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            public static readonly Font FallbackHeaderFont = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        }
        
        // Spacing and sizing
        public static class Spacing
        {
            public const int ExtraSmall = 4;
            public const int Small = 8;
            public const int Medium = 12;
            public const int Large = 16;
            public const int ExtraLarge = 24;
            public const int XxLarge = 32;
        }
        
        // Modern styling values
        public static class Styling
        {
            public const int BorderRadius = 6;
            public const int CardElevation = 2;
            public const int ButtonHeight = 32;
            public const int InputHeight = 36;
        }
    }
}