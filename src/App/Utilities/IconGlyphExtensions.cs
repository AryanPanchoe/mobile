using Bit.Core;
using Bit.Core.Enums;
using Bit.Core.Models.View;

namespace Bit.App.Utilities
{
    public static class IconGlyphExtensions
    {
        public static string GetIcon(this CipherView cipher)
        {
            switch (cipher.Type)
            {
                case CipherType.Login:
                    return GetLoginIconGlyph(cipher);
                case CipherType.SecureNote:
                    return VaultwardenIcons.StickyNote;
                case CipherType.Card:
                    return VaultwardenIcons.CreditCard;
                case CipherType.Identity:
                    return VaultwardenIcons.IdCard;
            }
            return null;
        }

        static string GetLoginIconGlyph(CipherView cipher)
        {
            var icon = VaultwardenIcons.Globe;
            if (cipher.Login.Uri != null)
            {
                var hostnameUri = cipher.Login.Uri;
                if (hostnameUri.StartsWith(Constants.AndroidAppProtocol))
                {
                    icon = VaultwardenIcons.Android;
                }
                else if (hostnameUri.StartsWith(Constants.iOSAppProtocol))
                {
                    icon = VaultwardenIcons.Apple;
                }
            }
            return icon;
        }

        public static string GetBooleanIconGlyph(bool value, BooleanGlyphType type)
        {
            switch (type)
            {
                case BooleanGlyphType.Checkbox:
                    return value ? VaultwardenIcons.CheckSquare : VaultwardenIcons.Square;
                case BooleanGlyphType.Eye:
                    return value ? VaultwardenIcons.EyeSlash : VaultwardenIcons.Eye;
                default:
                    return "";
            }
        }
    }

    public enum BooleanGlyphType
    {
        Checkbox,
        Eye
    }
}
