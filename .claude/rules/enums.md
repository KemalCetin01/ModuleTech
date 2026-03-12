# Enum Tanımları

## BelgeDurumEnum
`sys_belge.BelgeDurumEnum` alanında kullanılır.

```typescript
enum BelgeDurumEnum {
  Aktif                  = 1,
  SuresiDoldu            = 2,
  Iptal                  = 3,
  YenilemeBasvurusuYapildi = 4,
  UygunsuzlukSuresiVerildi = 5,
  FaaliyetSonlandirilmaIptal = 6,
  AskiyaAl               = 7,  // "Askıya al" şemadan
}
```

**Kullanım kuralları:**
- Fiziksel silme yapma — `Iptal (3)` kullan
- Süre dolduğunda sistem otomatik `SuresiDoldu (2)` atar
- Yenileme başvurusu yapılınca `YenilemeBasvurusuYapildi (4)` güncelle

---

## BelgeTipi
`sys_belge.Belge_Tipi` alanında kullanılır.

```typescript
enum BelgeTipi {
  BasvuruImza                = 1,  // Başvuru imza (il müd. gfb/izin/lisans)
  IlMudDegerlendirmeOnay     = 2,  // il müd Degerlendirme-Onay
  IlMudDegerlendirmeRed      = 3,  // il müd Degerlendirme-Red
  GfbDegUzun                 = 4,  // gfb değ uzun
  GfbIzinLisans              = 5,  // gfb izin lisans
  GfbDegerlendirmeBelgesi    = 6,  // gfb değerlendirme belgesi
  GfbEksiklikYazisi          = 7,  // gfb eksiklik yazısı
  IzinLisansBelgesi          = 8,  // İzinLisans belgesi
  IzinLisansDegerlendirme    = 9,  // izinlisans değerlendirme belgesi
}
```

---

## BelgeSablonKategoriEnum
`BelgeSablon.kategori_enum` alanında kullanılır.

```typescript
enum BelgeSablonKategoriEnum {
  GFB            = 'GFB',
  IzinLisans     = 'IzinLisans',
  UygunlukYazisi = 'UygunlukYazisi',
  RetYazisi      = 'RetYazisi',
  IadeYazisi     = 'IadeYazisi',
  UstYazi        = 'UstYazi',
}
```

---

## MuafiyetDurumEnum
`EkListeKalem.Muafiyet_durum` alanında kullanılır.

```typescript
enum MuafiyetDurumEnum {
  GurultuMuafiyeti      = 'gurultu_muafiyeti',
  HavaEmisyonuMuafiyeti = 'hava_emisyonu_muafiyeti',
}
```

---

## KonuTipiEnum
`IzinLisansKonu.konu_tipi` alanında kullanılır.

```typescript
enum KonuTipiEnum {
  Izin    = 'izin',
  Lisans  = 'lisans',
}
```

---

## İzin Lisans Konu Tipleri (veri, enum değil)
Sistemde tanımlı başlıca konular:

- Hava Emisyonu
- Çevresel Gürültü
- Atıksu Deşarjı
- Derin Deniz Deşarjı
- (Lisans konuları — IzinLisansKonu tablosundan çekilir)
