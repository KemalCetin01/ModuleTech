---
name: implement-usecase
description: UseCase.md'den belirtilen UC kodunu okur ve implementasyon plani cikarir
tools: Read, Glob, Grep
---

## Adim 1: Use Case'i Bul
- `src/UseCase.md` dosyasini oku
- Kullanicinin belirttigi UC kodunu bul (ornek: UC-BSV-003)
- Use case bilgilerini cikar: ID, Ad, Aktorler, On Kosullar, Temel Akis, Alternatif Akislar, Istisnalar, Is Kurallari

## Adim 2: Analiz
- Hangi entity'ler gerekli?
- Hangi CQRS command/query'ler olusturulmali?
- Hangi validation kurallari uygulanmali?
- Baska modullerle bagimlilik var mi?
- Hangi dis sistem entegrasyonlari gerekli?

## Adim 3: Implementasyon Plani
Asagidaki formatta plan cikar:

### Gerekli Entity'ler
| Entity | Base Class | Ozellikler |

### Gerekli Command'lar
| Command | Aciklama | Validation Kurallari |

### Gerekli Query'ler
| Query | Aciklama | Filter Alanlari |

### Modul Bagimliliklari
| Bagimli Modul | Bagimlilik Turu |

### Dis Sistem Entegrasyonlari
| Sistem | Entegrasyon Turu |

### Onerilen Implementasyon Sirasi
1. Entity'ler
2. Repository + Service
3. Command/Query Handler'lar
4. Controller endpoint'ler
5. Migration

## Adim 4: Mevcut Kod Kontrolu
- Bu use case ile ilgili mevcut kod var mi kontrol et
- Tekrar kullanilabilecek mevcut servis/repository var mi?
