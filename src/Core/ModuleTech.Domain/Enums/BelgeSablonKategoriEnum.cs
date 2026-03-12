using System.ComponentModel;

namespace ModuleTech.Domain.Enums;

public enum BelgeSablonKategoriEnum
{
    [Description("GFB")]
    GFB                 = 1,

    [Description("IzinLisans")]
    IzinLisans          = 2,

    [Description("UygunlukYazisi")]
    UygunlukYazisi      = 3,

    [Description("RetYazisi")]
    RetYazisi           = 4,

    [Description("IadeYazisi")]
    IadeYazisi          = 5,

    [Description("UstYazi")]
    UstYazi             = 6,
}
