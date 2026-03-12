using System.ComponentModel;

namespace ModuleTech.Domain.Enums;

public enum MuafiyetDurumEnum
{
    [Description("gurultu_muafiyeti")]
    GurultuMuafiyeti        = 1,

    [Description("hava_emisyonu_muafiyeti")]
    HavaEmisyonuMuafiyeti   = 2,
}
