# e-İzin Projesi - Use Case Dokümanı

## Modül Yapısı
| Modül Kodu | Modül Adı                        | Use Case Sayısı |
|------------|----------------------------------|-----------------|
| SYS        | Sistem Yönetimi ve Konfigürasyon | 8               |
| KUL        | Kullanıcı ve Yetki Yönetimi      | 6               |
| CG         | Çevre Görevlisi İşlemleri        | 5               |
| BSV        | Başvuru Süreçleri                | 8               |
| DEG        | Değerlendirme Süreçleri          | 9               |
| YEN        | Yenileme ve Güncelleme Süreçleri | 8               |
| MUA        | Muafiyet İşlemleri               | 4               |
| IPT        | İptal Süreçleri                  | 7               |@
| OZL        | Görüş ve Özel İşlemler           | 5               |
| BLG        | Belge Yönetimi                   | 5               |
| RPR        | Raporlama ve Analitik            | 6               |
| ENT        | Entegrasyon Yönetimi             | 6               |
| BLD        | Bildirim Sistemi                 | 4               |
| TOPLAM     |                                  | 81              |
---

## Aktörler

| Aktör                        | Açıklama                                                  | Tip         | 
|------------------------------|-----------------------------------------------------------|-------------|                                                                                                               
| Çevre Görevlisi (ÇG)         | Tesisler adına başvuru yapan, e-Yeterlik belgeli personel | Birincil    |                                                                                                                
| Çevre Danışman Firması (ÇDF) | Çevre görevlilerini istihdam eden danışmanlık firması     | Birincil    |                                                                                                                
| Çevre Yönetim Birimi (ÇYB)   | İşletme bünyesindeki çevre yönetim birimi                 | Birincil    |                                                                                                                
| Firma Yetkilisi              | İşletme sahibi veya yetkili temsilcisi                    | Birincil    |                                                                                                                
| İl Müdürlüğü Personeli       | İl Çevre Müdürlüğü değerlendirme personeli                | Birincil    |                                                                                                                
| Bakanlık Personeli           | Bakanlık merkez teşkilatı değerlendirme personeli         | Birincil    |                                                                                                                
| Şube Müdürü                  | İl Müdürlüğü veya Bakanlık şube müdürü                    | Birincil    |                                                                                                                
| Sistem Yöneticisi            | Sistem parametrelerini yöneten admin kullanıcı            | Birincil    |                                                                                                                
| e-Yeterlik Sistemi           | Çevre görevlisi yetkilendirme sistemi                     | Dış Sistem  |                                                                                                                
| Belgenet                     | Elektronik belge yönetim sistemi                          | Dış Sistem  |                                                                                                                
| TOBB/TESK                    | Kapasite raporu sağlayan kurum                            | Dış Sistem  |                                                                                                                
| e-ÇED Sistemi                | ÇED karar sorgulama sistemi                               | Dış Sistem  |                                                                                                                
| Döner Sermaye                | Ödeme sistemi                                             | Dış Sistem  |                                                                                                                

## Aktör İlişkileri

```
┌─────────────────────────────────────────────────────────────────────────────────────────┐
│                                    e-İZİN SİSTEMİ                                       │
├─────────────────────────────────────────────────────────────────────────────────────────┤
│                                                                                         │
│  ╔═══════════════════════════════════════════════════════════════════════════════════╗  │
│  ║                         BAŞVURU YAPAN AKTÖRLER                                    ║  │
│  ╠═══════════════════════════════════════════════════════════════════════════════════╣  │
│  ║                                                                                   ║  │
│  ║  ┌─────────────┐     ┌────────────────────────────────┐                           ║  │
│  ║  │     ÇG      │────▶│ Başvuru Oluşturma/Güncelleme   │                           ║  │
│  ║  │  (Çevre     │     │ Tesis Bilgisi Yönetimi         │                           ║  │
│  ║  │ Görevlisi)  │     │ Belge Yükleme/Takip            │                           ║  │
│  ║  └──────┬──────┘     │ Eksiklik Tamamlama             │                           ║  │
│  ║         │            └────────────────────────────────┘                           ║  │
│  ║         │ istihdam                                                                ║  │
│  ║         ▼                                                                         ║  │
│  ║  ┌─────────────┐     ┌────────────────────────────────┐                           ║  │
│  ║  │    ÇDF      │────▶│ ÇG Atama/Değiştirme            │                           ║  │
│  ║  │  (Çevre     │     │ Sözleşme Yönetimi              │                           ║  │
│  ║  │  Danışman   │     │ Tesis Portföy Yönetimi         │                           ║  │
│  ║  │  Firması)   │     │ Koordinasyon                   │                           ║  │
│  ║  └─────────────┘     └────────────────────────────────┘                           ║  │
│  ║                                                                                   ║  │
│  ║  ┌─────────────┐     ┌────────────────────────────────┐                           ║  │
│  ║  │    ÇYB      │────▶│ Kendi Tesisi İçin Başvuru      │                           ║  │
│  ║  │  (Çevre     │     │ Belge Takibi                   │                           ║  │
│  ║  │  Yönetim    │     │ Eksiklik Tamamlama             │                           ║  │
│  ║  │  Birimi)    │     └────────────────────────────────┘                           ║  │
│  ║  └─────────────┘                                                                  ║  │
│  ║                                                                                   ║  │
│  ║  ┌─────────────┐     ┌────────────────────────────────┐                           ║  │
│  ║  │   Firma     │────▶│ Tesis Bilgisi Görüntüleme      │                           ║  │
│  ║  │  Yetkilisi  │     │ Başvuru Durumu Takibi          │                           ║  │
│  ║  └─────────────┘     │ Belge İndirme                  │                           ║  │
│  ║                      └────────────────────────────────┘                           ║  │
│  ╚═══════════════════════════════════════════════════════════════════════════════════╝  │
│                                                                                         │
│  ╔═══════════════════════════════════════════════════════════════════════════════════╗  │
│  ║                      DEĞERLENDİRME YAPAN AKTÖRLER                                 ║  │
│  ╠═══════════════════════════════════════════════════════════════════════════════════╣  │
│  ║                                                                                   ║  │
│  ║  ┌─────────────┐     ┌────────────────────────────────┐                           ║  │
│  ║  │ İl Müd.     │────▶│ EK-2 Başvuru Değerlendirme     │                           ║  │
│  ║  │ Personeli   │     │ GFB/ÇİB Değerlendirme          │                           ║  │
│  ║  └──────┬──────┘     │ Eksiklik Bildirme              │                           ║  │
│  ║         │            │ Karar Hazırlama                │                           ║  │
│  ║         │ onay       └────────────────────────────────┘                           ║  │
│  ║         ▼                                                                         ║  │
│  ║  ┌─────────────┐     ┌────────────────────────────────┐                           ║  │
│  ║  │   Şube      │────▶│ Değerlendirme Onayı            │                           ║  │
│  ║  │  Müdürü     │     │ Belge İmzalama                 │                           ║  │
│  ║  └─────────────┘     │ Red/Kabul Kararı               │                           ║  │
│  ║                      └────────────────────────────────┘                           ║  │
│  ║                                                                                   ║  │
│  ║  ┌─────────────┐     ┌────────────────────────────────┐                           ║  │
│  ║  │  Bakanlık   │────▶│ EK-1 Başvuru Değerlendirme     │                           ║  │
│  ║  │  Personeli  │     │ Üst Düzey Onay                 │                           ║  │
│  ║  └─────────────┘     │ Politika Belirleme             │                           ║  │
│  ║                      └────────────────────────────────┘                           ║  │
│  ╚═══════════════════════════════════════════════════════════════════════════════════╝  │
│                                                                                         │
│  ╔═══════════════════════════════════════════════════════════════════════════════════╗  │
│  ║                           SİSTEM YÖNETİMİ                                         ║  │
│  ╠═══════════════════════════════════════════════════════════════════════════════════╣  │
│  ║  ┌─────────────┐     ┌────────────────────────────────┐                           ║  │
│  ║  │   Sistem    │────▶│ Parametre Yönetimi             │                           ║  │
│  ║  │  Yöneticisi │     │ Şablon Yönetimi                │                           ║  │
│  ║  └─────────────┘     │ Organizasyon Yönetimi          │                           ║  │
│  ║                      │ Kullanıcı Yetkilendirme        │                           ║  │
│  ║                      └────────────────────────────────┘                           ║  │
│  ╚═══════════════════════════════════════════════════════════════════════════════════╝  │
│                                                                                         │
└───────────┬─────────────────────┬─────────────────────┬─────────────────────┬───────────┘
            │                     │                     │                     │
            ▼                     ▼                     ▼                     ▼
┌───────────────────┐ ┌───────────────────┐ ┌───────────────────┐ ┌───────────────────┐
│   e-Yeterlik      │ │     Belgenet      │ │    TOBB/TESK      │ │    e-ÇED          │
│   Sistemi         │ │                   │ │                   │ │    Sistemi        │
│                   │ │ Belge arşivleme   │ │ Kapasite raporu   │ │                   │
│ ÇG yetki kontrol  │ │ Resmi yazışma     │ │ sorgulama         │ │ ÇED karar         │
└───────────────────┘ └───────────────────┘ └───────────────────┘ │ sorgulama         │
                                                                  └───────────────────┘
                                            ┌───────────────────┐
                                            │  Döner Sermaye    │
                                            │                   │
                                            │ Ödeme işlemleri   │
                                            │ Harç tahsilatı    │
                                            └───────────────────┘
```

### Aktör İlişki Matrisi

| Aktör | İlişkili Aktörler | İlişki Türü |
|-------|-------------------|-------------|
| ÇG | ÇDF, Firma Yetkilisi | ÇDF tarafından istihdam edilir, Firma adına işlem yapar |
| ÇDF | ÇG | ÇG'leri istihdam eder ve yönetir |
| ÇYB | Firma Yetkilisi | Firma bünyesinde çalışır |
| İl Müd. Personeli | Şube Müdürü | Şube Müdürüne bağlı çalışır |
| Şube Müdürü | İl Müd. Personeli, Bakanlık Personeli | Personeli yönetir, Bakanlığa raporlar |
| Bakanlık Personeli | Şube Müdürü | EK-1 için üst makam |
                                                                                                                                                                                                                           
---       

### Ana Süreç Akışı

```
[İl Md. Uygunluk Başvurusu] ──► [GFB Başvurusu] ──► [İzin/Lisans Başvurusu]
         │                            │                      │
         ▼                            ▼                      ▼
   [Değerlendirme]             [Değerlendirme]        [Değerlendirme]
         │                            │                      │
    ┌────┴────┐                  ┌────┴────┐            ┌────┴────┐
    ▼         ▼                  ▼         ▼            ▼         ▼
[Uygun]   [Red/İade]         [Uygun]   [Red/İade]   [Uygun]   [Red]
    │         │                  │         │            │
    ▼         │                  ▼         │            ▼
[Uygunluk    │              [GFB Belgesi] │      [İzin/Lisans
 Yazısı]     │                   │         │       Belgesi]
             │                   │         │
             └───────────────────┴─────────┘
                        │
                        ▼
              [Süreç Başa Döner]
```

---
## MODÜL 1: SİSTEM YÖNETİMİ VE KONFİGÜRASYON (SYS)

### UC-SYS-001: Sistem Parametrelerini Tanımlama                                                                                                                                                                             

| Alan                 | Değer                                                                                                        |  
|----------------------|--------------------------------------------------------------------------------------------------------------|                                                                           
| Use Case ID          | UC-SYS-001                                                                                                   |                                                                                     
| Use Case Adı         | Sistem Yöneticisi İş Kuralı Parametrelerini Tanımlar                                                         |                                                                                     
| Aktörler             | Birincil: Sistem Yöneticisi                                                                                  |                                                                                     
| Ön Koşullar          | 1. Sistem Yöneticisi sisteme giriş yapmış olmalıdır2. Kullanıcı "Sistem Yönetimi" yetkisine sahip olmalıdır  |                                                                                     
| Başarılı Son Koşul   | Sistem parametreleri veritabanına kaydedilir ve tüm süreçlerde aktif olarak kullanılır                       | 
| Öncelik/Kritiklik    | Kritik                                                                                                       |                                                                                                                                                                                             
| İlgili İş Kuralları  | BR-SYS-001: Parametre değişiklikleri anlık olarak devreye girerBR-SYS-002: Parametre geçmişi 10 yıl saklanır |                                                                                   
| İlgili Gereksinimler | FR-SYS-001, FR-SYS-002, FR-SYS-003, FR-SYS-004, FR-SYS-005, FR-SYS-006                                       |                                                                                                            
| Notlar/Varsayımlar   | Kritik parametrelerde (belge süreleri, bedeller) değişiklik için üst yönetici onayı gerekebilir              |                                                                                    
#### Temel Akış (Main Success Scenario)                                                                                                                                                                                       
| Adım | Açıklama                                                                               | 
|------|----------------------------------------------------------------------------------------| 
| 1    | Sistem Yöneticisi "Sistem Yönetimi > Parametre Yönetimi" menüsünü açar                 |                                                                                                                        
| 2    | Sistem mevcut parametre kategorilerini listeler (Süreler, Bedeller, İş Kuralları)      |                                                                                                                        
| 3    | Sistem Yöneticisi düzenlemek istediği parametre kategorisini seçer                     |                                                                                                                        
| 4    | Sistem seçilen kategorideki parametreleri ve mevcut değerlerini gösterir               |                                                                                                                        
| 5    | Sistem Yöneticisi parametre değerini günceller (örn: GFB değerlendirme süresi: 30 gün) |                                                                                                                        
| 6    | Sistem Yöneticisi geçerlilik başlangıç tarihini belirler                               |                                                                                                                        
| 7    | Sistem Yöneticisi "Kaydet" butonuna tıklar                                             |                                                                                                                        
| 8    | Sistem parametreyi doğrular (format, aralık kontrolü)                                  |                                                                                                                        
| 9    | Sistem parametreyi kaydeder ve versiyon numarası atar                                  |                                                                                                                        
| 10   | Sistem "Parametre başarıyla güncellendi" mesajı gösterir                               |                                                                                                                        
#### Alternatif Akışlar                                                                                                                                                                                                       
| Kod  | Koşul                                          | Akış                                                                                                                |  
|------|------------------------------------------------|---------------------------------------------------------------------------------------------------------------------|                                         
| 5a   | Sistem Yöneticisi yeni parametre eklemek ister | 5a1. "Yeni Parametre Ekle" butonuna tıklar<br/>5a2. Parametre adı, tipi, varsayılan değer girer<br/>5a3. Adım 7'ye devam eder |                                           
| 6a   | Geriye dönük geçerlilik tarihi girilir         | 6a1. Sistem uyarı mesajı gösterir6<br/>a2. Onay istenir<br/>6a3. Onaylanırsa devam eder                                       |                                           
#### İstisnalar                                                                                                                                                                                                               
| Kod | Durum                                        | Akış                                                                                  |   
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                                                                                 
| 8a  | Parametre değeri geçersiz formatta           | 8a1. Sistem hata mesajı gösterir<br/>8a2. Geçerli format belirtilir<br/>8a3. Kullanıcı düzeltir |                                                                           
| 8b  | Parametre değeri izin verilen aralık dışında | 8b1. Sistem min/max değerleri gösterir<br/>8b2. Kullanıcı uygun değer girer                |

### UC-SYS-002: İzin/Lisans Konularını Yönetme                                                                                                                                                                               
| Alan                 |                                                Değer                                                 |    
|----------------------|----------------------------------------------------------------------------------------|                                                                                                                                 
| Use Case ID          | UC-SYS-002                                                                                           |                                                                                            
| Use Case Adı         | Sistem Yöneticisi İzin/Lisans Konularını Tanımlar ve Günceller                                       |                                                                                            
| Aktörler             | Birincil: Sistem Yöneticisi                                                                          |                                                                                            
| Ön Koşullar          | 1. Sistem Yöneticisi sisteme giriş yapmış olmalıdır2. "Veri Tanımları Yönetimi" yetkisi bulunmalıdır |                                                                                            
| Başarılı Son Koşul   | İzin/Lisans konuları güncel haliyle sistemde tanımlı olur                                            |       
| Öncelik/Kritiklik    | Kritik |                                                                                                                                                                                             
| İlgili İş Kuralları  | BR-SYS-010: Lisans konuları EK-3C'de tanımlı olmalıdır |                                                                                                                                         
| İlgili Gereksinimler | FR-SYS-010, FR-SYS-012 |                                                                                                                                                                        
| Notlar/Varsayımlar   | İzin konuları: Hava Emisyonu, Çevresel Gürültü, Atıksu Deşarjı, Derin Deniz Deşarjı |                                                                                     
#### Temel Akış                                                                                                                                                                                                               
| Adım |                                         Açıklama                                          |   
|------|----------------------------------------------------------------------------------------|                                                                                                                    
| 1    | Sistem Yöneticisi "Sistem Yönetimi > Veri Tanımları > İzin/Lisans Konuları" menüsünü açar |                                                                                                                     
| 2    | Sistem mevcut konuları hiyerarşik olarak listeler (İzin Konuları / Lisans Konuları)       |                                                                                                                     
| 3    | Sistem Yöneticisi düzenlemek istediği konuyu seçer                                        |                                                                                                                     
| 4    | Sistem konu detaylarını gösterir (Kod, Ad, Üst Kategori, Durum, Gerekli Belgeler)         |                                                                                                                     
| 5    | Sistem Yöneticisi gerekli alanları günceller                                              |                                                                                                                     
| 6    | Sistem Yöneticisi konu-belge eşleşmelerini tanımlar (EK-3B, EK-3C belgeleri)              |                                                                                                                     
| 7    | Sistem Yöneticisi "Kaydet" butonuna tıklar                                                |                                                                                                                     
| 8    | Sistem değişiklikleri doğrular ve kaydeder                                                |                                                                                                                     
| 9    | Sistem "Konu başarıyla güncellendi" mesajı gösterir                                       |                                                                                                                     
#### Alternatif Akışlar                                                                                                                                                                                                       
| Kod |            Koşul            |                                                              Akış                                                               |  
|------|----------------------------------------------------------------------------------------| ---|                                                                                         
| 3a  | Yeni konu eklenmek istenir  | 3a1. "Yeni Konu Ekle" butonuna tıklar<br/>3a2. Konu tipi seçilir (İzin/Lisans)<br/>3a3. Gerekli bilgiler girilir<br/>3a4. Adım 7'ye devam eder |                                                  
| 5a  | Konu pasife alınmak istenir | 5a1. "Pasife Al" seçilir<br/>5a2. Sistem aktif başvuru kontrolü yapar<br/>5a3. Aktif başvuru yoksa pasife alır                            |                                                  
#### İstisnalar                                                                                                                                                                                                               
| Kod |              Durum              |                                           Akış                                            |   
|------|----------------------------------------------------------------------------------------| ---|                                                                                                                          
| 5a2 | Konuya ait aktif başvuru mevcut | Sistem "Bu konuya ait X adet aktif başvuru bulunmaktadır. Pasife alınamaz." uyarısı verir |  

### UC-SYS-003: EK-1/EK-2 Listelerini Yönetme                                                                                                                                                                                
|        Alan        |                                     Değer                                      |
|--------------------|-------------------------------------------------------------------------------------------------------------|                                                                                                                    
| Use Case ID        | UC-SYS-003                                                                     |                                                                                                                  
| Use Case Adı       | Sistem Yöneticisi EK-1/EK-2 Tesis Listelerini Günceller                        |                                                                                                                  
| Aktörler           | Birincil: Sistem Yöneticisi                                                    |                                                                                                                  
| Ön Koşullar        | 1. Sisteme giriş yapılmış olmalıdır2. "EK Liste Yönetimi" yetkisi bulunmalıdır |                                                                                                                  
| Başarılı Son Koşul | EK-1/EK-2 listeleri mevzuata uygun şekilde güncellenmiş olur                   |    
| Öncelik/Kritiklik | Kritik |                                                                                                                                                                                             
| İlgili İş Kuralları | BR-SYS-014: EK-1 tesisler Bakanlık yetkisinde, EK-2 tesisler İl Müdürlüğü yetkisindedir |                                                                                                        
| İlgili Gereksinimler | FR-SYS-014, FR-BSV-001, FR-BSV-002 |                                                                                                                                                            
| Notlar/Varsayımlar | EK listeleri mevzuat değişikliklerine göre periyodik olarak güncellenir |                                                                                                              
#### Temel Akış                                                                                                                                                                                                               
| Adım |                                          Açıklama                                           |
|------|----------------------------------------------------------------------------------------|                                                                                                                    
| 1    | Sistem Yöneticisi "Sistem Yönetimi > Veri Tanımları > EK Listeleri" menüsünü açar           |                                                                                                                   
| 2    | Sistem EK-1 ve EK-2 listelerini kategorize ederek gösterir                                  |                                                                                                                   
| 3    | Sistem Yöneticisi düzenlemek istediği listeyi (EK-1 veya EK-2) seçer                        |                                                                                                                   
| 4    | Sistem seçilen listedeki sektörleri ve alt kalemleri ağaç yapısında gösterir                |                                                                                                                   
| 5    | Sistem Yöneticisi bir kalem seçer                                                           |                                                                                                                   
| 6    | Sistem kalemin detaylarını gösterir (Sektör, Alt Sektör, Kapasite Eşiği, Muafiyet Durumu)   |                                                                                                                   
| 7    | Sistem Yöneticisi kapasite eşiklerini ve muafiyet durumlarını günceller                     |                                                                                                                   
| 8    | Sistem Yöneticisi dipnot bilgilerini günceller (Gürültü muafiyeti, Hava emisyonu muafiyeti) |                                                                                                                   
| 9    | Sistem Yöneticisi "Kaydet" butonuna tıklar                                                  |                                                                                                                   
| 10   | Sistem değişiklikleri doğrular ve kaydeder                                                  |                                                                                                                   
#### Alternatif Akışlar                                                                                                                                                                                                       
| Kod |                Koşul                 |                                          Akış                                          |     
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                                                
| 5a  | Yeni sektör/kalem eklenir            | 5a1. "Yeni Kalem Ekle" seçilir<br/>5a2. Üst kategori belirlenir<br/>5a3. Kalem bilgileri girilir |                                                                                  
| 8a  | Birden fazla dipnot ilişkilendirilir | 8a1. Dipnot çoklu seçim yapılır<br/>8a2. Her dipnot için geçerlilik durumu belirlenir       |      

### UC-SYS-004: Organizasyon Şemasını Görüntüleme ve Yönetme
|        Alan        |                                        Değer                                         |
|--------------------|-------------------------------------------------------------------------------------------------------------|
| Use Case ID        | UC-SYS-004                                                                           |
| Use Case Adı       | Sistem Organizasyon Şemasını Entegrasyonla Alır ve Görüntüler                        |
| Aktörler           | Birincil: Sistem Yöneticisiİkincil: Entegrasyon Sistemi (Ortak Modül)                |
| Ön Koşullar        | 1. Sisteme giriş yapılmış olmalıdır2. "Organizasyon Yönetimi" yetkisi bulunmalıdır3. Ortak Modül entegrasyonu aktif olmalıdır |
| Başarılı Son Koşul | Organizasyon şeması entegrasyondan alınır, hiyerarşik olarak görüntülenir ve başvuru yönlendirmede kullanılır |
| Öncelik/Kritiklik | Kritik |
| İlgili İş Kuralları | BR-SYS-020: Her İl Müdürlüğü yalnızca kendi ilindeki EK-2 başvurularını değerlendirir |
| İlgili Gereksinimler | FR-SYS-020, FR-SYS-021, FR-SYS-025 |
| Notlar/Varsayımlar | 81 İl Müdürlüğü ve Bakanlık merkez teşkilatı Ortak Modül'den senkronize edilir |
#### Temel Akış
| Adım |                                                   Açıklama                                                   |
|------|----------------------------------------------------------------------------------------|
| 1    | Sistem Yöneticisi "Sistem Yönetimi > Organizasyon Yönetimi" menüsünü açar                                    |
| 2    | Sistem Ortak Modül entegrasyonundan organizasyon şemasını çeker                                              |
| 3    | Sistem organizasyon şemasını ağaç yapısında gösterir (Bakanlık > İl Müdürlükleri > Şube Müdürlükleri)        |
| 4    | Sistem Yöneticisi bir birim seçer                                                                            |
| 5    | Sistem birim detaylarını gösterir (Ad, Kod, Üst Birim, Sorumlu İller, Yetki Alanı)                           |
| 6    | Sistem Yöneticisi birime atanacak EK kapsamını belirler (EK-1: Bakanlık, EK-2: İl Md.)                       |
| 7    | Sistem Yöneticisi e-İzin'e özel yetki alanı eşleştirmelerini yapar                                           |
| 8    | Sistem Yöneticisi "Kaydet" butonuna tıklar                                                                   |
| 9    | Sistem e-İzin'e özel eşleştirmeleri kaydeder (organizasyon verisi salt okunur)                               |
| 10   | Sistem otomatik yönlendirme kurallarını günceller                                                            |
#### Alternatif Akışlar
| Kod |       Koşul        |                                                     Akış                                                     |
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|
| 2a  | Entegrasyon hatası | 2a1. Sistem hata mesajı gösterir2a2. Son başarılı senkronizasyondaki veri gösterilir2a3. Admin bilgilendirilir |
| 3a  | Manuel senkronizasyon | 3a1. "Senkronize Et" butonuna tıklanır3a2. Sistem Ortak Modül'den güncel veriyi çeker |       

### UC-SYS-005: Onay Akışlarını Yapılandırma                                                                                                                                                                                 
|        Alan        |                                     Değer                                      |
|--------------------|-------------------------------------------------------------------------------------------------------------|                                                                                                                   
| Use Case ID        | UC-SYS-005                                                                     |                                                                                                                  
| Use Case Adı       | Sistem Yöneticisi Onay Akışlarını Tanımlar                                     |                                                                                                                  
| Aktörler           | Birincil: Sistem Yöneticisi                                                    |                                                                                                                  
| Ön Koşullar        | 1. Organizasyon şeması tanımlı olmalıdır2. Kullanıcı rolleri tanımlı olmalıdır |                                                                                                                  
| Başarılı Son Koşul | Süreç bazlı onay akışları tanımlanır ve başvurularda otomatik uygulanır        | 
| Öncelik/Kritiklik | Kritik |                                                                                                                                                                                             
| İlgili İş Kuralları | BR-SYS-022: EK-1 başvuruları Bakanlık onayı gerektirir |                                                                                                                                         
| İlgili Gereksinimler | FR-SYS-022, FR-SYS-023 |                                                                                                                                                                        
| Notlar/Varsayımlar | Onay akışları süreç ve EK kapsamına göre farklılaşabilir |                                                                                                                 
#### Temel Akış                                                                                                                                                                                                               
| Adım |                                         Açıklama                                          |  
|------|----------------------------------------------------------------------------------------|                                                                                                                    
| 1    | Sistem Yöneticisi "Sistem Yönetimi > Onay Akışları" menüsünü açar                         |                                                                                                                     
| 2    | Sistem mevcut süreçleri listeler (İl Md. Uygunluk, GFB, İzin/Lisans, Yenileme vb.)        |                                                                                                                     
| 3    | Sistem Yöneticisi yapılandırmak istediği süreci seçer                                     |                                                                                                                     
| 4    | Sistem mevcut onay akışını görsel olarak gösterir (akış şeması)                           |                                                                                                                     
| 5    | Sistem Yöneticisi onay adımlarını sırayla tanımlar                                        |                                                                                                                     
| 6    | Her adım için onay verecek rolü/kullanıcı tipini belirler                                 |                                                                                                                     
| 7    | Sistem Yöneticisi paralel/sıralı onay seçeneklerini yapılandırır                          |                                                                                                                     
| 8    | Sistem Yöneticisi çoklu onay gereksinimini aktifleştirir (ÇG + ÇDF/ÇYB + Firma Yetkilisi) |                                                                                                                     
| 9    | Sistem Yöneticisi "Kaydet" butonuna tıklar                                                |                                                                                                                     
| 10   | Sistem akışı doğrular ve kaydeder                                                         |                                                                                                                     
#### Alternatif Akışlar                                                                                                                                                                                                       
| Kod |            Koşul            |                                            Akış                                            |   
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                                                       
| 7a  | Koşullu yönlendirme eklenir | 7a1. Koşul tipi seçilir (EK kapsamı, konu tipi vb.)7a2. Koşula göre farklı akış tanımlanır |                                                                                       

### UC-SYS-006: Belge Şablonlarını Yönetme                                                                                                                                                                                   
|        Alan        |                                    Değer                                     |
|--------------------|-------------------------------------------------------------------------------------------------------------|                                                                                                                     
| Use Case ID        | UC-SYS-006                                                                   |                                                                                                                    
| Use Case Adı       | Sistem Yöneticisi Belge Şablonlarını Oluşturur ve Günceller                  |                                                                                                                    
| Aktörler           | Birincil: Sistem Yöneticisi                                                  |                                                                                                                    
| Ön Koşullar        | 1. Sisteme giriş yapılmış olmalıdır2. "Şablon Yönetimi" yetkisi bulunmalıdır |                                                                                                                    
| Başarılı Son Koşul | Belge şablonları tanımlanır ve otomatik belge üretiminde kullanılır          |    
| Öncelik/Kritiklik | Kritik |                                                                                                                                                                                             
| İlgili İş Kuralları | BR-SYS-030: Her belge tipi için en az bir aktif şablon bulunmalıdır |                                                                                                                            
| İlgili Gereksinimler | FR-SYS-030, FR-SYS-031, FR-SYS-032 |                                                                                                                                                
| Notlar/Varsayımlar | Şablonlar mevzuat değişikliklerinde güncellenir ve eski versiyonlar arşivlenir |                                                                                                                
#### Temel Akış                                                                                                                                                                                                               
| Adım |                                                   Açıklama                                                   |  
|------|----------------------------------------------------------------------------------------|                                                                                                 
| 1    | Sistem Yöneticisi "Sistem Yönetimi > Şablon Yönetimi" menüsünü açar                                          |                                                                                                  
| 2    | Sistem şablon kategorilerini listeler (GFB, İzin/Lisans, Uygunluk Yazısı, Red Yazısı, İade Yazısı, Üst Yazı) |                                                                                                  
| 3    | Sistem Yöneticisi düzenlemek istediği şablon kategorisini seçer                                              |                                                                                                  
| 4    | Sistem mevcut şablonları ve versiyonlarını listeler                                                          |                                                                                                  
| 5    | Sistem Yöneticisi bir şablonu seçer veya yeni şablon oluşturur                                               |                                                                                                  
| 6    | Sistem şablon editörünü açar (Word benzeri arayüz)                                                           |                                                                                                  
| 7    | Sistem Yöneticisi şablon içeriğini düzenler                                                                  |                                                                                                  
| 8    | Sistem Yöneticisi dinamik alanları ekler ({TesisAdi}, {Tarih}, {BelgeNo}, {IzinKonusu} vb.)                  |                                                                                                  
| 9    | Sistem Yöneticisi şablonu önizler                                                                            |                                                                                                  
| 10   | Sistem Yöneticisi "Kaydet" butonuna tıklar                                                                   |                                                                                                  
| 11   | Sistem şablonu versiyonlayarak kaydeder                                                                      |                                                                                                  
#### Alternatif Akışlar                                                                                                                                                                                                       
| Kod |             Koşul             |                                           Akış                                           |      
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                                                    
| 5a  | Mevcut şablon kopyalanır      | 5a1. "Kopyala" seçilir5a2. Yeni şablon adı girilir5a3. Kopya üzerinde değişiklik yapılır |                                                                                       
| 9a  | Önizlemede hata tespit edilir | 9a1. Dinamik alan hataları gösterilir9a2. Kullanıcı hataları düzeltir                    |  

### UC-SYS-007: Atık Kodlarını Yönetme                                                                                                                                                                                       
|        Alan        |                                        Değer                                         |  
|--------------------|-------------------------------------------------------------------------------------------------------------|                                                                                                             
| Use Case ID        | UC-SYS-007                                                                           |                                                                                                            
| Use Case Adı       | Sistem Yöneticisi Atık Kodlarını Tanımlar ve Günceller                               |                                                                                                            
| Aktörler           | Birincil: Sistem Yöneticisi                                                          |                                                                                                            
| Ön Koşullar        | 1. Sisteme giriş yapılmış olmalıdır2. "Veri Tanımları Yönetimi" yetkisi bulunmalıdır |                                                                                                            
| Başarılı Son Koşul | Atık kodları ve açıklamaları sistemde tanımlı olur                                   |   
| Öncelik/Kritiklik | Kritik |                                                                                                                                                                                             
| İlgili İş Kuralları | BR-SYS-011: Atık kodları Avrupa Atık Listesi ile uyumlu olmalıdır |                                                                                                                              
| İlgili Gereksinimler | FR-SYS-011, FR-SYS-013 |                                                                                                                                                                        
| Notlar/Varsayımlar | Atık kodları 6 haneli standart formatta tanımlanır (örn: 17 01 01) |                                                                                                         
#### Temel Akış                                                                                                                                                                                                               
| Adım |                                              Açıklama                                              |   
|------|----------------------------------------------------------------------------------------|                                                                                                          
| 1    | Sistem Yöneticisi "Sistem Yönetimi > Veri Tanımları > Atık Kodları" menüsünü açar                  |                                                                                                            
| 2    | Sistem atık kodlarını hiyerarşik olarak listeler (Ana Kategori > Alt Kategori > Atık Kodu)         |                                                                                                            
| 3    | Sistem Yöneticisi düzenlemek istediği atık kodunu arar/seçer                                       |                                                                                                            
| 4    | Sistem atık kodu detaylarını gösterir (Kod, Açıklama, Tehlikelilik Durumu, İlgili Lisans Konuları) |                                                                                                            
| 5    | Sistem Yöneticisi bilgileri günceller                                                              |                                                                                                            
| 6    | Sistem Yöneticisi atık kodu - lisans konusu eşleşmesini tanımlar                                   |                                                                                                            
| 7    | Sistem Yöneticisi "Kaydet" butonuna tıklar                                                         |                                                                                                            
| 8    | Sistem değişiklikleri kaydeder                                                                     |                                                                                                            
#### Alternatif Akışlar                                                                                                                                                                                                       
| Kod |         Koşul          |                                         Akış                                          |   
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                                                                 
| 3a  | Yeni atık kodu eklenir | 3a1. "Yeni Atık Kodu" seçilir<br/>3a2. Üst kategori belirlenir<br/>3a3. Kod ve açıklama girilir |                                                                                                 
| 6a  | Toplu eşleşme yapılır  | 6a1. Birden fazla atık kodu seçilir<br/>6a2. Ortak lisans konusu atanır                    |                                                                                                 

### UC-SYS-008: Duyuru ve Menü Yapısını Yönetme                                                                                                                                                                              
|        Alan        |                                    Değer                                     |  
|--------------------|-------------------------------------------------------------------------------------------------------------|                                                                                                                     
| Use Case ID        | UC-SYS-008                                                                   |                                                                                                                    
| Use Case Adı       | Sistem Yöneticisi Duyuru Yayınlar ve Menü Yapısını Düzenler                  |                                                                                                                    
| Aktörler           | Birincil: Sistem Yöneticisi                                                  |                                                                                                                    
| Ön Koşullar        | 1. Sisteme giriş yapılmış olmalıdır2. "İçerik Yönetimi" yetkisi bulunmalıdır |                                                                                                                    
| Başarılı Son Koşul | Duyurular yayınlanır ve menü yapısı güncellenir                              |  
| Öncelik/Kritiklik | Orta |                                                                                                                                                                                             
| İlgili İş Kuralları | BR-SYS-040: Duyurular en fazla 90 gün aktif kalabilir |                                                                                                                                          
| İlgili Gereksinimler | FR-SYS-040, FR-SYS-041 |                                                                                                                                                                        
| Notlar/Varsayımlar | Kritik duyurular (mevzuat değişikliği) zorunlu okunur olarak işaretlenebilir |                                                                                                                  
#### Temel Akış                                                                                                                                                                                                               
| Adım |                                                             Açıklama                                                              |
|------|----------------------------------------------------------------------------------------|                                                                            
| 1    | Sistem Yöneticisi "Sistem Yönetimi > İçerik Yönetimi" menüsünü açar                                                               |                                                                             
| 2    | Sistem "Duyurular" ve "Menü Yönetimi" sekmelerini gösterir                                                                        |                                                                             
| 3    | Sistem Yöneticisi "Duyurular" sekmesini seçer                                                                                     |                                                                             
| 4    | Sistem mevcut duyuruları listeler (Aktif/Pasif, Tarih, Hedef Kitle)                                                               |                                                                             
| 5    | Sistem Yöneticisi "Yeni Duyuru" butonuna tıklar                                                                                   |                                                                             
| 6    | Sistem duyuru formunu açar                                                                                                        |                                                                             
| 7    | Sistem Yöneticisi duyuru başlığı, içeriği, geçerlilik tarihleri ve hedef kitleyi (Tüm kullanıcılar, ÇG, Değerlendirici vb.) girer |                                                                             
| 8    | Sistem Yöneticisi "Yayınla" butonuna tıklar                                                                                       |                                                                             
| 9    | Sistem duyuruyu yayınlar ve hedef kitleye bildirim gönderir                                                                       |                                                                             
#### Alternatif Akışlar                                                                                                                                                                                                       
| Kod |         Koşul          |                                                                      Akış                                                                       |  
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                        
| 3a  | Menü yapısı düzenlenir | 3a1. "Menü Yönetimi" sekmesi seçilir3a2. Menü ağacı sürükle-bırak ile düzenlenir3a3. Yeni menü öğesi eklenir3a4. Rol bazlı görünürlük ayarlanır |     

---                                                                                                                                                                                                                      

## MODÜL 2: KULLANICI VE YETKİ YÖNETİMİ (KUL)

### UC-KUL-001: Kullanıcı Rollerini Tanımlama                                                                                                                                                                                
|        Alan        |                                   Değer                                   |
|--------------------|-------------------------------------------------------------------------------------------------------------|                                                                                                                         
| Use Case ID        | UC-KUL-001                                                                |                                                                                                                       
| Use Case Adı       | Sistem Yöneticisi Kullanıcı Rollerini Tanımlar                            |                                                                                                                       
| Aktörler           | Birincil: Sistem Yöneticisi                                               |                                                                                                                       
| Ön Koşullar        | 1. Sisteme giriş yapılmış olmalıdır2. "Rol Yönetimi" yetkisi bulunmalıdır |                                                                                                                       
| Başarılı Son Koşul | Roller tanımlanır ve kullanıcılara atanabilir hale gelir                  |     
| Öncelik/Kritiklik | Kritik |                                                                                                                                                                                             
| İlgili İş Kuralları | BR-KUL-001: Her rol benzersiz bir koda sahip olmalıdır |                                                                                                                                         
| İlgili Gereksinimler | FR-USR-001, FR-USR-002 |                                                                                                                                                                        
| Notlar/Varsayımlar | Standart roller: ÇG, ÇDF, ÇYB, Firma Yetkilisi, Koordinatör, Tesis Yetkilisi, İl Md. Personeli, Bakanlık Personeli, Şube Müdürü, İl Müdürü |                                                                                                                  
#### Temel Akış                                                                                                                                                                                                               
| Adım |                                                       Açıklama                                                        |  
|------|----------------------------------------------------------------------------------------|                                                                                        
| 1    | Sistem Yöneticisi "Kullanıcı Yönetimi > Rol Tanımları" menüsünü açar                                                  |                                                                                         
| 2    | Sistem mevcut rolleri listeler (ÇG, ÇDF, ÇYB, Firma Yetkilisi, İl Md. Personeli, Bakanlık Personeli, Şube Müdürü vb.) |                                                                                         
| 3    | Sistem Yöneticisi düzenlemek istediği rolü seçer veya "Yeni Rol" oluşturur                                            |                                                                                         
| 4    | Sistem rol detay ekranını açar                                                                                        |                                                                                         
| 5    | Sistem Yöneticisi rol adı ve açıklamasını girer                                                                       |                                                                                         
| 6    | Sistem Yöneticisi menü yetkilerini belirler (hangi menülere erişebilir)                                               |                                                                                         
| 7    | Sistem Yöneticisi sayfa yetkilerini belirler (görüntüleme, düzenleme, silme)                                          |                                                                                         
| 8    | Sistem Yöneticisi işlem yetkilerini belirler (başvuru yapma, değerlendirme, onaylama vb.)                             |                                                                                         
| 9    | Sistem Yöneticisi veri yetkilerini belirler (hangi verileri görebilir - kendi ili, tüm iller vb.)                     |                                                                                         
| 10   | Sistem Yöneticisi "Kaydet" butonuna tıklar                                                                            |                                                                                         
| 11   | Sistem rolü kaydeder                                                                                                  |                                                                                         
#### Alternatif Akışlar                                                                                                                                                                                                       
| Kod |         Koşul         |                                           Akış                                           |              
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                                                    
| 3a  | Mevcut rol kopyalanır | 3a1. "Kopyala" seçilir3a2. Yeni rol adı girilir3a3. Yetkiler üzerinde değişiklik yapılır |                                                                                               
| 6a  | Tüm yetkiler seçilir  | 6a1. "Tümünü Seç" işaretlenir6a2. İstenmeyen yetkiler tek tek kaldırılır                 |  

### UC-KUL-002: Kullanıcıya Rol Atama                                                                                                                                                                                        
|        Alan        |                                           Değer                                           |
|--------------------|-------------------------------------------------------------------------------------------------------------|                                                                                                       
| Use Case ID        | UC-KUL-002                                                                                |                                                                                                       
| Use Case Adı       | Yetkili Kullanıcı Sistemdeki Kullanıcılara Rol Atar                                       |                                                                                                       
| Aktörler           | Birincil: Sistem Yöneticisi, Birim Yöneticisi                                             |                                                                                                       
| Ön Koşullar        | 1. Kullanıcı Hesap Modülü'nde tanımlı olmalıdır2. Atanacak rol sistemde tanımlı olmalıdır |                                                                                                       
| Başarılı Son Koşul | Kullanıcıya rol atanır ve yetkileri aktif hale gelir                                      |    
| Öncelik/Kritiklik | Kritik |                                                                                                                                                                                             
| İlgili İş Kuralları | BR-KUL-002: Bir kullanıcı birden fazla role sahip olabilir |                                                                                                                                     
| İlgili Gereksinimler | FR-USR-003, FR-USR-004 |                                                                                                                                                                        
| Notlar/Varsayımlar | Rol değişiklikleri audit logunda tutulur |                                                                                                   
#### Temel Akış                                                                                                                                                                                                               
| Adım |                                    Açıklama                                     |  
|------|----------------------------------------------------------------------------------------|                                                                                                                               
| 1    | Yetkili kullanıcı "Kullanıcı Yönetimi > Kullanıcı Listesi" menüsünü açar        |                                                                                                                               
| 2    | Sistem kullanıcıları listeler (ad, soyad, TC kimlik, mevcut roller)             |                                                                                                                               
| 3    | Yetkili kullanıcı rol atamak istediği kullanıcıyı arar ve seçer                 |                                                                                                                               
| 4    | Sistem kullanıcı detay ekranını açar                                            |                                                                                                                               
| 5    | Yetkili kullanıcı "Roller" sekmesine geçer                                      |                                                                                                                               
| 6    | Sistem mevcut atanmış rolleri ve atanabilir rolleri gösterir                    |                                                                                                                               
| 7    | Yetkili kullanıcı yeni rol seçer                                                |                                                                                                                               
| 8    | Sistem rol için ek parametre gerekiyorsa (örn: sorumlu il) giriş alanı gösterir |                                                                                                                               
| 9    | Yetkili kullanıcı parametreleri doldurur                                        |                                                                                                                               
| 10   | Yetkili kullanıcı "Kaydet" butonuna tıklar                                      |                                                                                                                               
| 11   | Sistem rol atamasını kaydeder ve audit logu oluşturur                           |                                                                                                                               
| 12   | Sistem kullanıcıya bildirim gönderir                                            |                                                                                                                               
#### Alternatif Akışlar                                                                                                                                                                                                       
| Kod |          Koşul          |                                           Akış                                            |    
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                                                           
| 7a  | Birden fazla rol atanır | 7a1. Birden fazla rol seçilir7a2. Her rol için ayrı parametreler girilir                  |                                                                                            
| 7b  | Mevcut rol kaldırılır   | 7b1. Kaldırılacak rol seçilir7b2. "Rolü Kaldır" tıklanır7b3. Aktif işlem kontrolü yapılır |                                                                                            
#### İstisnalar                                                                                                                                                                                                               
| Kod |                 Durum                  |                                                       Akış                                                        |   
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                     
| 7b3 | Kullanıcının bu rolle aktif işlemi var | Sistem uyarı verir: "Bu rolle devam eden X işlem bulunmaktadır. Önce işlemler tamamlanmalı veya devredilmelidir." |     

### UC-KUL-003: Vekalet Tanımlama                                                                                                                                                                                            
|        Alan        |                                                Değer                                                 |  
|--------------------|-------------------------------------------------------------------------------------------------------------|                                                                                            
| Use Case ID        | UC-KUL-003                                                                                           |                                                                                            
| Use Case Adı       | Kullanıcı Başka Bir Kullanıcıya Vekalet Tanımlar                                                     |                                                                                            
| Aktörler           | Birincil: Vekalet veren kullanıcıİkincil: Birim Yöneticisi (onay için)                               |                                                                                            
| Ön Koşullar        | 1. Her iki kullanıcı da sistemde tanımlı olmalıdır2. Vekil kullanıcı uygun yetkilere sahip olmalıdır |                                                                                            
| Başarılı Son Koşul | Vekalet tanımlanır ve belirtilen tarih aralığında aktif olur                                         | 
| Öncelik/Kritiklik | Orta |                                                                                                                                                                                             
| İlgili İş Kuralları | BR-KUL-010: Vekalet ile yapılan işlemler hem vekil hem asıl kullanıcı adına loglanır |                                                                                                           
| İlgili Gereksinimler | FR-USR-010, FR-USR-011, FR-USR-012, FR-USR-013 |                                                                                                                                                
| Notlar/Varsayımlar | Vekalet süresi en fazla 90 gün olabilir, uzatma için yeni vekalet gerekir |                                                                                           
#### Temel Akış                                                                                                                                                                                                               
| Adım |                                              Açıklama                                               |
|------|----------------------------------------------------------------------------------------|                                                                                                           
| 1    | Kullanıcı "Hesabım > Vekalet Yönetimi" menüsünü açar                                                |                                                                                                           
| 2    | Sistem mevcut ve geçmiş vekaletleri listeler                                                        |                                                                                                           
| 3    | Kullanıcı "Yeni Vekalet" butonuna tıklar                                                            |                                                                                                           
| 4    | Sistem vekalet tanımlama formunu açar                                                               |                                                                                                           
| 5    | Kullanıcı vekil olacak kullanıcıyı seçer (arama ile)                                                |                                                                                                           
| 6    | Kullanıcı vekalet başlangıç ve bitiş tarihlerini girer                                              |                                                                                                           
| 7    | Kullanıcı vekalet kapsamını belirler (tüm yetkiler veya seçili yetkiler)                            |                                                                                                           
| 8    | Kullanıcı vekalet süresince kendi erişiminin durumunu seçer (erişim devam eder / erişim kısıtlanır) |                                                                                                           
| 9    | Kullanıcı "Kaydet" butonuna tıklar                                                                  |                                                                                                           
| 10   | Sistem vekaleti kaydeder ve onay sürecini başlatır (gerekiyorsa)                                    |                                                                                                           
| 11   | Sistem vekil kullanıcıya bildirim gönderir                                                          |                                                                                                           
#### Alternatif Akışlar                                                                                                                                                                                                       
| Kod |             Koşul              |                                                       Akış                                                       |  
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                               
| 7a  | Kısmi vekalet tanımlanır       | 7a1. "Seçili Yetkiler" seçilir7a2. Devredilecek yetkiler tek tek işaretlenir                                     |                                                              
| 10a | Birim yöneticisi onayı gerekir | 10a1. Vekalet "Onay Bekliyor" durumuna geçer10a2. Birim yöneticisine bildirim gider10a3. Onay sonrası aktif olur |                                                              
#### İstisnalar                                                                                                                                                                                                               
| Kod |                 Durum                 |                      Akış                       |         
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                                                                                  
| 5a  | Vekil kullanıcının yetkileri yetersiz | Sistem uyarı verir ve uygun kullanıcı önerir    |                                                                                                                        
| 6a  | Tarih aralığı çakışması var           | Sistem mevcut vekalet ile çakışma uyarısı verir |

### UC-KUL-004: Hesap Modülünden Kullanıcı Bilgilerini Senkronize Etme                                                                                                                                                       
|        Alan        |                                          Değer                                           |  
|--------------------|-------------------------------------------------------------------------------------------------------------|                                                                                                       
| Use Case ID        | UC-KUL-004                                                                               |                                                                                                        
| Use Case Adı       | Sistem Hesap Modülünden Kullanıcı Bilgilerini Otomatik Senkronize Eder                   |                                                                                                        
| Aktörler           | Birincil: Sistem (otomatik)İkincil: Hesap Modülü (dış sistem)                            |                                                                                                        
| Ön Koşullar        | 1. Hesap Modülü entegrasyonu aktif olmalıdır2. Web servis bağlantısı sağlanmış olmalıdır |                                                                                                        
| Başarılı Son Koşul | Kullanıcı, firma ve tesis bilgileri güncel olarak e-İzin sistemine aktarılır             |    
| Öncelik/Kritiklik | Kritik |                                                                                                                                                                                             
| İlgili İş Kuralları | BR-KUL-020: Hesap Modülü kaynak sistemdir, e-İzin'de kullanıcı bilgisi değiştirilemez |                                                                                                          
| İlgili Gereksinimler | FR-USR-020, FR-USR-021, FR-USR-022, FR-ENT-001 |                                                                                                                                                
| Notlar/Varsayımlar | Senkronizasyon hatalarında e-posta bildirimi gönderilir |                                                                                                    
#### Temel Akış                                                                                                                                                                                                               
| Adım |                                   Açıklama                                    |   
|------|----------------------------------------------------------------------------------------|                                                                                                                                
| 1    | Sistem tanımlı periyotta (örn: her 6 saatte) senkronizasyon işlemini başlatır |                                                                                                                                 
| 2    | Sistem Hesap Modülü web servisine bağlanır                                    |                                                                                                                                 
| 3    | Sistem son senkronizasyondan sonra değişen kayıtları sorgular                 |                                                                                                                                 
| 4    | Hesap Modülü değişen kişi, firma ve tesis kayıtlarını döner                   |                                                                                                                                 
| 5    | Sistem dönen verileri doğrular (format, zorunlu alan kontrolü)                |                                                                                                                                 
| 6    | Sistem yeni kayıtları ekler                                                   |                                                                                                                                 
| 7    | Sistem güncellenen kayıtları günceller                                        |                                                                                                                                 
| 8    | Sistem pasife alınan kayıtları işaretler                                      |                                                                                                                                 
| 9    | Sistem senkronizasyon logunu oluşturur                                        |                                                                                                                                 
| 10   | Sistem başarılı/başarısız kayıt sayılarını raporlar                           |                                                                                                                                 
#### Alternatif Akışlar                                                                                                                                                                                                       
| Kod |              Koşul               |                                           Akış                                           |
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                                                      
| 1a  | Manuel senkronizasyon tetiklenir | 1a1. Sistem Yöneticisi "Manuel Senkronizasyon" butonuna tıklar1a2. Adım 2'den devam eder |                                                                                    
| 4a  | Çok sayıda kayıt var             | 4a1. Sistem sayfalı olarak veri çeker4a2. Her sayfa için adım 5-8 tekrarlanır            |                                                                                    
#### İstisnalar                                                                                                                                                                                                               
| Kod |              Durum              |                            Akış                            |         
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                                                                             
| 2a  | Web servis bağlantısı başarısız | Sistem hata loglar ve belirlenen süre sonra tekrar dener   |                                                                                                                   
| 5a  | Veri doğrulama hatası           | Hatalı kayıt loglanır, diğer kayıtlar işlenmeye devam eder | 

### UC-KUL-005: Kullanıcı Oturumu Açma                                                                                                                                                                                       
|        Alan        |                                                 Değer                                                  |  
|--------------------|-------------------------------------------------------------------------------------------------------------|                                                                                          
| Use Case ID        | UC-KUL-005                                                                                             |                                                                                          
| Use Case Adı       | Kullanıcı Sisteme Giriş Yapar                                                                          |                                                                                          
| Aktörler           | Birincil: Tüm kullanıcı tipleriİkincil: UCBS Login Servisi                                             |                                                                                          
| Ön Koşullar        | 1. Kullanıcı Hesap Modülü'nde tanımlı olmalıdır2. Kullanıcının e-Devlet veya kurumsal hesabı olmalıdır |                                                                                          
| Başarılı Son Koşul | Kullanıcı sisteme giriş yapar ve yetkili olduğu ekranları görür                                        |    
| Öncelik/Kritiklik | Kritik |                                                                                                                                                                                             
| İlgili İş Kuralları | BR-KUL-005: 3 başarısız giriş denemesinden sonra hesap 30 dakika kilitlenir |                                                                                                                    
| İlgili Gereksinimler | FR-USR-020, FR-ENT-001 |                                                                                                                                                                        
| Notlar/Varsayımlar | Oturum süresi 30 dakika inaktivite sonrası otomatik sonlanır |                                                                                      
#### Temel Akış                                                                                                                                                                                                               
| Adım |                                 Açıklama                                 |  
|------|----------------------------------------------------------------------------------------|                                                                                                                                     
| 1    | Kullanıcı e-İzin giriş sayfasına erişir                                  |                                                                                                                                      
| 2    | Sistem giriş seçeneklerini gösterir (e-Devlet, Kurumsal Giriş)           |                                                                                                                                      
| 3    | Kullanıcı giriş yöntemini seçer                                          |                                                                                                                                      
| 4    | Sistem kullanıcıyı ilgili kimlik doğrulama sayfasına yönlendirir         |                                                                                                                                      
| 5    | Kullanıcı kimlik bilgilerini girer ve doğrulama yapar                    |                                                                                                                                      
| 6    | Kimlik doğrulama servisi başarılı yanıt döner                            |                                                                                                                                      
| 7    | Sistem kullanıcı bilgilerini Hesap Modülü'nden çeker                     |                                                                                                                                      
| 8    | Sistem kullanıcının rollerini ve yetkilerini yükler                      |                                                                                                                                      
| 9    | Sistem kullanıcı oturumunu oluşturur                                     |                                                                                                                                      
| 10   | Sistem kullanıcıyı ana sayfaya yönlendirir                               |                                                                                                                                      
| 11   | Sistem son giriş bilgilerini gösterir ve okunmamış bildirimleri listeler |                                                                                                                                      
#### Alternatif Akışlar                                                                                                                                                                                                       
| Kod |          Koşul          |                                             Akış                                             |  
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                                                          
| 3a  | e-Devlet ile giriş      | 3a1. e-Devlet giriş sayfası açılır3a2. TC Kimlik ve şifre/mobil imza ile doğrulama yapılır   |                                                                                         
| 3b  | Kurumsal giriş          | 3b1. Kurumsal giriş sayfası açılır3b2. Kullanıcı adı ve şifre ile doğrulama yapılır          |                                                                                         
| 8a  | Birden fazla rol mevcut | 8a1. Sistem aktif rol seçim ekranı gösterir8a2. Kullanıcı hangi rolle giriş yapacağını seçer |                                                                                         
#### İstisnalar                                                                                                                                                                                                               
| Kod |               Durum               |                                             Akış                                             |     
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                                             
| 6a  | Kimlik doğrulama başarısız        | Sistem hata mesajı gösterir: "Giriş bilgileri hatalı"                                        |                                                                               
| 7a  | Kullanıcı e-İzin'de tanımlı değil | Sistem uyarı gösterir: "Sisteme erişim yetkiniz bulunmamaktadır"                             |                                                                               
| 8b  | Kullanıcının aktif rolü yok       | Sistem uyarı gösterir: "Aktif rolünüz bulunmamaktadır. Lütfen yöneticinizle iletişime geçin" |                                                                              

### UC-KUL-006: Rol Değişikliklerini Audit Etme                                                                                                                                                                              
|        Alan        |                                     Değer                                      |  
|--------------------|-------------------------------------------------------------------------------------------------------------|                                                                                                                  
| Use Case ID        | UC-KUL-006                                                                     |                                                                                                                  
| Use Case Adı       | Sistem Yöneticisi Rol Değişiklik Geçmişini İnceler                             |                                                                                                                  
| Aktörler           | Birincil: Sistem Yöneticisi, Denetçi                                           |                                                                                                                  
| Ön Koşullar        | 1. Sisteme giriş yapılmış olmalıdır2. "Audit Görüntüleme" yetkisi bulunmalıdır |                                                                                                                  
| Başarılı Son Koşul | Rol değişiklikleri raporlanır ve denetlenebilir                                |    
| Öncelik/Kritiklik | Orta |                                                                                                                                                                                             
| İlgili İş Kuralları | BR-KUL-006: Audit logları 10 yıl saklanır ve silinemez |                                                                                                                                         
| İlgili Gereksinimler | FR-USR-004 |                                                                                                                                                                                    
| Notlar/Varsayımlar | KVKK uyumluluğu için audit logları anonimleştirilebilir |                                                                                                              
#### Temel Akış                                                                                                                                                                                                               
| Adım |                                             Açıklama                                              |  
|------|----------------------------------------------------------------------------------------|                                                                                                             
| 1    | Yetkili kullanıcı "Kullanıcı Yönetimi > Audit Logları" menüsünü açar                              |                                                                                                             
| 2    | Sistem filtreleme seçeneklerini gösterir (Tarih aralığı, Kullanıcı, İşlem tipi)                   |                                                                                                             
| 3    | Yetkili kullanıcı filtreleme kriterlerini girer                                                   |                                                                                                             
| 4    | Yetkili kullanıcı "Ara" butonuna tıklar                                                           |                                                                                                             
| 5    | Sistem rol değişiklik kayıtlarını listeler (Tarih, Kullanıcı, Eski Rol, Yeni Rol, Değiştiren, IP) |                                                                                                             
| 6    | Yetkili kullanıcı detay görmek istediği kaydı seçer                                               |                                                                                                             
| 7    | Sistem değişiklik detaylarını gösterir                                                            |                                                                                                             
| 8    | Yetkili kullanıcı raporu dışa aktarabilir (Excel, PDF)                                            |                                                                                                             

---                                                                                                                                                                                                                      

## MODÜL 3: ÇEVRE GÖREVLİSİ İŞLEMLERİ (CG)

### UC-CG-001: Sorumlu Tesisleri Görüntüleme                                                                                                                                                                                 
|        Alan        |                                           Değer                                            |
|--------------------|-------------------------------------------------------------------------------------------------------------|                                                                                                       
| Use Case ID        | UC-CG-001                                                                                  |                                                                                                      
| Use Case Adı       | Çevre Görevlisi Sorumlu Olduğu Tesisleri Listeler                                          |                                                                                                      
| Aktörler           | Birincil: Çevre Görevlisi (ÇG)İkincil: e-Yeterlik Sistemi                                  |                                                                                                      
| Ön Koşullar        | 1. ÇG sisteme giriş yapmış olmalıdır2. ÇG'nin e-Yeterlik'te tanımlı tesisleri bulunmalıdır |                                                                                                      
| Başarılı Son Koşul | ÇG sorumlu olduğu tesisleri görür ve seçim yapabilir                                       |   
| Öncelik/Kritiklik | Kritik |                                                                                                                                                                                             
| İlgili İş Kuralları | BR-CG-001: ÇG sadece e-Yeterlik'te tanımlı tesisler için işlem yapabilir |                                                                                                                       
| İlgili Gereksinimler | FR-CG-001, FR-CG-002, FR-CG-020, FR-CG-021 |                                                                                                                                                    
| Notlar/Varsayımlar | Tesis listesi her erişimde e-Yeterlik'ten güncel olarak çekilir |                                                                                                   
#### Temel Akış                                                                                                                                                                                                               
| Adım |                                                            Açıklama                                                            |  
|------|----------------------------------------------------------------------------------------|                                                                               
| 1    | ÇG "Tesislerim" menüsüne tıklar                                                                                                |                                                                                
| 2    | Sistem e-Yeterlik servisini çağırarak ÇG'nin yetkili olduğu tesisleri sorgular    (ORTAKTAN GELİR)                                              |                                                                                
| 3    | e-Yeterlik servisi tesis listesini döner  (ORTAKTAN GELİR)                                                                                     |                                                                                
| 4    | Sistem tesisleri kartlar halinde listeler (Tesis Adı, İl, EK Kapsamı, Belge Durumu, Son İşlem)                                 |                                                                                
| 5    | Sistem her tesis için durum göstergesi gösterir (Yeşil: Belge geçerli, Sarı: Yenileme yaklaşıyor, Kırmızı: Belge yok/geçersiz) |                                                                                
| 6    | ÇG tesis listesini filtreleyebilir (İl, Durum, EK Kapsamı)                                                                     |                                                                                
| 7    | ÇG detay görmek istediği tesisi seçer                                                                                          |                                                                                
| 8    | Sistem tesis detay sayfasını açar                                                                                              |                                                                                
#### Alternatif Akışlar                                                                                                                                                                                                       
| Kod |              Koşul              |                                            Akış                                             |  
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                                                   
| 3a  | e-Yeterlik servisi yanıt vermez | 3a1. Sistem önbellekteki listeyi gösterir3a2. "Veriler güncel olmayabilir" uyarısı gösterir |                                                                                  
| 6a  | Arama ile tesis bulunur         | 6a1. ÇG arama kutusuna tesis adı/kodu yazar6a2. Sistem eşleşen tesisleri filtreler          |                                                                                  
#### İstisnalar                                                                                                                                                                                                               
| Kod |           Durum           |                                                        Akış                                                         |      
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                             
| 3b  | ÇG'nin tanımlı tesisi yok | Sistem "Sorumlu olduğunuz tesis bulunmamaktadır. e-Yeterlik sisteminden tesis tanımı yapılmalıdır." mesajı gösterir |                                                                

### UC-CG-002: Tesis İçin Yapılabilecek İşlemleri Görüntüleme                                                                                                                                                                
|        Alan        |                                     Değer                                    |   
|--------------------|-----------------------------------------------------------------------------------------------------------|                                                                                                                  
| Use Case ID        | UC-CG-002                                                                    |                                                                                                                  
| Use Case Adı       | Çevre Görevlisi Seçili Tesis İçin Yapılabilecek İşlemleri Görür              |                                                                                                                  
| Aktörler           | Birincil: Çevre Görevlisi                                                    |                                                                                                                  
| Ön Koşullar        | 1. ÇG bir tesis seçmiş olmalıdır2. Tesisin mevcut durumu belirlenmiş olmalıdır |                                                                                                                  
| Başarılı Son Koşul | ÇG tesis durumuna uygun yapılabilecek işlemleri görür                        |   
| Öncelik/Kritiklik | Kritik |                                                                                                                                                                                             
| İlgili İş Kuralları | BR-CG-002: İşlemler tesisin belge durumuna göre dinamik olarak belirlenir |                                                                                                                      
| İlgili Gereksinimler | FR-CG-003, FR-CG-010, FR-CG-011, FR-CG-012 |                                                                                                                                                    
| Notlar/Varsayımlar | İşlem akışı mevzuata göre belirlenir: Uygunluk → GFB → İzin/Lisans |                                                                                                               
#### Temel Akış                                                                                                                                                                                                               
| Adım |                                       Açıklama                                        |   
|------|----------------------------------------------------------------------------------------|                                                                                                                        
| 1    | ÇG tesis detay sayfasında "İşlemler" sekmesine tıklar                                 |                                                                                                                         
| 2    | Sistem tesisin mevcut durumunu kontrol eder (belgesi var mı, hangi aşamada, süreleri) |                                                                                                                         
| 3    | Sistem yapılabilecek işlemleri kategorize ederek listeler:                            |                                                                                                                         
|      | - Yeni Başvuru: İl Md. Uygunluk Başvurusu (belge yoksa)                               |                                                                                                                         
|      | - Devam Eden Süreç: GFB Başvurusu, İzin/Lisans Başvurusu                              |                                                                                                                         
|      | - Yenileme/Güncelleme: Belge Yenileme, Atık Kodu Ekleme, Konu Değişikliği             |                                                                                                                         
|      | - Diğer: Görüş Talebi, Faaliyet Sonlandırma                                           |                                                                                                                         
| 4    | Sistem her işlem için ön koşul kontrolü yapar                                         |                                                                                                                         
| 5    | Sistem yapılabilir işlemleri aktif, yapılamaz işlemleri pasif (gri) gösterir          |                                                                                                                         
| 6    | Sistem pasif işlemler için neden yapılamadığını tooltip ile gösterir                  |                                                                                                                         
| 7    | ÇG yapmak istediği işlemi seçer                                                       |                                                                                                                         
| 8    | Sistem ilgili başvuru formunu açar                                                    |                                                                                                                         
#### Alternatif Akışlar                                                                                                                                                                                                       
| Kod |              Koşul               |                                                              Akış                                                              |  
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                               
| 3a  | Tesisin devam eden başvurusu var | 3a1. Sistem "Devam Eden Başvuru" kartını öne çıkarır<br/>3a2. Başvuru durumu ve kalan süre gösterilir3a3. "Devam Et" butonu eklenir |                                              
| 5a  | Tüm işlemler pasif               | 5a1. Sistem uyarı gösterir: "Bu tesis için şu an yapılabilecek işlem bulunmamaktadır"5a2. Neden yapılamadığı açıklanır         |

### UC-CG-003: Tesis Başvuru Durumunu e-Yeterlik'e İletme
|        Alan        |                                           Değer                                            |
|--------------------|--------------------------------------------------------------------------------------------|
| Use Case ID        | UC-CG-003                                                                                  |
| Use Case Adı       | Sistem Tesis Başvuru Durumlarını e-Yeterlik Uygulamasına İletir                            |
| Aktörler           | Birincil: Sistem (Otomatik)İkincil: e-Yeterlik Sistemi                                     |
| Ön Koşullar        | 1. e-Yeterlik entegrasyonu aktif olmalıdır2. Başvuru durumu değişmiş olmalıdır             |
| Başarılı Son Koşul | Başvuru durumu e-Yeterlik sistemine başarıyla iletilir                                     |
| Öncelik/Kritiklik  | Kritik                                                                                     |
| İlgili İş Kuralları | BR-CG-003: Her başvuru durum değişikliği e-Yeterlik'e anlık olarak bildirilir             |
| İlgili Gereksinimler | FR-CG-022, FR-ENT-024                                                                    |
| Notlar/Varsayımlar | Entegrasyon web servis üzerinden sağlanır, hata durumunda yeniden deneme mekanizması vardır |
#### Temel Akış
| Adım |                                               Açıklama                                                |
|------|-------------------------------------------------------------------------------------------------------|
| 1    | Çevre görevlisi bir başvuru işlemi gerçekleştirir (yeni başvuru, güncelleme, tamamlama vb.)           |
| 2    | Sistem başvuru durumunu günceller                                                                     |
| 3    | Sistem e-Yeterlik web servisini çağırır                                                               |
| 4    | Sistem aşağıdaki bilgileri e-Yeterlik'e iletir:                                                       |
|      | - Tesis ID                                                                                            |
|      | - Çevre Görevlisi TC Kimlik No                                                                        |
|      | - Başvuru Tipi (İl Md. Uygunluk, GFB, İzin/Lisans)                                                    |
|      | - Başvuru Durumu (Taslak, Gönderildi, Değerlendirmede, Uygun, Red, İptal)                             |
|      | - Belge Numarası (varsa)                                                                              |
|      | - Belge Geçerlilik Tarihleri (varsa)                                                                  |
| 5    | e-Yeterlik sistemi veriyi alır ve onay döner                                                          |
| 6    | Sistem işlem logunu kaydeder                                                                          |
#### Alternatif Akışlar﻿
| Kod |              Koşul              |                                            Akış                                             |
|-----|-------------------------------  |---------------------------------------------------------------------------------------------|
| 5a  | e-Yeterlik servisi yanıt vermez | 5a1. Sistem hatayı loglar5a2. Kuyruğa alır ve 5 dk sonra tekrar dener5a3. 3 deneme sonrası admin bilgilendirilir |
| 3a  | Entegrasyon devre dışı          | 3a1. Sistem işlemi kuyruğa alır3a2. Entegrasyon aktif olduğunda toplu gönderim yapar        |
#### İstisnalar
| Kod |           Durum           |                                                        Akış                                                         |
|-----|---------------------------|---------------------------------------------------------------------------------------------------------------------|
| 4a  | Veri doğrulama hatası     | Sistem hatayı loglar ve admin bilgilendirilir                                                                       |

### UC-CG-004: Başvuru Taslağını Kaydetme                                                                                                                                                                                    
|        Alan        |                                     Değer                                     |  
|--------------------|-------------------------------------------------------------------------------------------------------------|                                                                                                                   
| Use Case ID        | UC-CG-004                                                                     |                                                                                                                   
| Use Case Adı       | Çevre Görevlisi Başvuru Taslağını Kaydeder                                    |                                                                                                                   
| Aktörler           | Birincil: Çevre Görevlisi                                                     |                                                                                                                   
| Ön Koşullar        | 1. Bir başvuru formu açılmış olmalıdır2. En az bir alan doldurulmuş olmalıdır |                                                                                                                   
| Başarılı Son Koşul | Başvuru taslak olarak kaydedilir ve sonra devam edilebilir                    |  
| Öncelik/Kritiklik | Kritik |                                                                                                                                                                                             
| İlgili İş Kuralları | BR-CG-004: Taslaklar 30 gün sonra otomatik silinir |                                                                                                                                             
| İlgili Gereksinimler | Genel kullanılabilirlik gereksinimi |                                                                                                                                                           
| Notlar/Varsayımlar | Her tesis için aynı türde tek taslak bulunabilir |                                                                                                                 
#### Temel Akış                                                                                                                                                                                                               
| Adım |                                Açıklama                                 |   
|------|----------------------------------------------------------------------------------------|                                                                                                                                     
| 1    | ÇG başvuru formunu doldurmaya başlar                                    |                                                                                                                                       
| 2    | ÇG istediği bir noktada "Taslak Kaydet" butonuna tıklar                 |                                                                                                                                       
| 3    | Sistem mevcut form verilerini doğrular (zorunlu alan kontrolü yapılmaz) |                                                                                                                                       
| 4    | Sistem taslağı benzersiz bir numara ile kaydeder                        |                                                                                                                                       
| 5    | Sistem "Taslak başarıyla kaydedildi" mesajı gösterir                    |                                                                                                                                       
| 6    | Sistem son kayıt zamanını gösterir                                      |                                                                                                                                       
| 7    | ÇG formu doldurmaya devam eder veya sayfadan ayrılır                    |                                                                                                                                       
#### Alternatif Akışlar                                                                                                                                                                                                       
| Kod |           Koşul            |                                                  Akış                                                  |    
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                                           
| 2a  | Otomatik taslak kaydetme   | 2a1. Sistem her 5 dakikada otomatik taslak kaydeder2a2. Kullanıcıya küçük bildirim gösterir            |                                                                            
| 7a  | Taslağa sonra devam edilir | 7a1. ÇG "Tesislerim > Taslak Başvurular" menüsüne girer7a2. Taslağı seçer ve kaldığı yerden devam eder |                                                                            
#### İstisnalar                                                                                                                                                                                                               
| Kod |        Durum         |                                  Akış                                  |              
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                                                                       
| 3a  | Oturum süresi dolmuş | Sistem giriş sayfasına yönlendirir, taslak mevcut verilerle kaydedilir |               

### UC-CG-005: Ek Belge Talebine Yanıt Verme                                                                                                                                                                                 
|        Alan        |                                             Değer                                             |
|--------------------|-------------------------------------------------------------------------------------------------------------|                                                                                                   
| Use Case ID        | UC-CG-005                                                                                     |                                                                                                   
| Use Case Adı       | Çevre Görevlisi Değerlendirici Tarafından İstenen Ek Belgeleri Yükler                         |                                                                                                   
| Aktörler           | Birincil: Çevre Görevlisi                                                                     |                                                                                                   
| Ön Koşullar        | 1. Başvuru "Ek Belge Bekleniyor" durumunda olmalıdır2. İstenen belgeler listelenmiş olmalıdır |                                                                                                   
| Başarılı Son Koşul | Ek belgeler yüklenir ve başvuru tekrar değerlendirmeye gönderilir                             |    
| Öncelik/Kritiklik | Kritik |                                                                                                                                                                                             
| İlgili İş Kuralları | BR-CG-005: Ek belge talebi imza süreci gerektirmez |                                                                                                                                             
| İlgili Gereksinimler | FR-DEG-010, FR-DEG-011 |                                                                                                                                                                        
| Notlar/Varsayımlar | Ek belge süresi eksiklik süresinden düşülmez |                                                                                               
#### Temel Akış                                                                                                                                                                                                               
| Adım |                          Açıklama                           |  
|------|----------------------------------------------------------------------------------------|                                                                                                                                                  
| 1    | ÇG sisteme giriş yapar ve bildirimlerini görür              |                                                                                                                                                   
| 2    | ÇG "Ek Belge Talebi" bildirimini seçer                      |                                                                                                                                                   
| 3    | Sistem başvuru detayını ve istenen belge listesini gösterir |                                                                                                                                                   
| 4    | Sistem her belge için not/açıklama varsa gösterir           |                                                                                                                                                   
| 5    | ÇG istenen belgeyi yükler (dosya seçimi)                    |                                                                                                                                                   
| 6    | Sistem dosya formatını ve boyutunu kontrol eder             |                                                                                                                                                   
| 7    | ÇG gerekirse açıklama ekler                                 |                                                                                                                                                   
| 8    | ÇG tüm istenen belgeleri yükler                             |                                                                                                                                                   
| 9    | ÇG "Gönder" butonuna tıklar                                 |                                                                                                                                                   
| 10   | Sistem başvuruyu "Değerlendirmede" durumuna geçirir         |                                                                                                                                                   
| 11   | Sistem değerlendiriciye bildirim gönderir                   |                                                                                                                                                   
#### Alternatif Akışlar                                                                                                                                                                                                       
| Kod |          Koşul           |                                               Akış                                               |   
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                                                    
| 5a  | Belge havuzundan seçilir | 5a1. "Havuzdan Seç" tıklanır5a2. Daha önce yüklenmiş belgeler listelenir5a3. Uygun belge seçilir |                                                                                    
| 8a  | Bazı belgeler yüklenemez | 8a1. Kısmi gönderim yapılabilir8a2. Yüklenemeyen belgeler için açıklama istenir                  |                                                                                    
#### İstisnalar                                                                                                                                                                                                               
| Kod |         Durum          |                                   Akış                                    |       
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                                                                         
| 6a  | Dosya formatı geçersiz | Sistem hata verir: "Yalnızca PDF, JPG, PNG formatları kabul edilmektedir" |                                                                                                             
| 6b  | Dosya boyutu aşıldı    | Sistem hata verir: "Dosya boyutu maksimum 10 MB olmalıdır"                |    
---                                                                                                                                                                                                                      

## MODÜL 4: BAŞVURU SÜREÇLERİ (BSV)

### UC-BSV-001: İl Müdürlüğü Uygunluk Başvurusu Oluşturma                                                                                                                                                                    
|        Alan        |                                                                             Değer                                                                             |
|--------------------|-------------------------------------------------------------------------------------------------------------|                                    
| Use Case ID        | UC-BSV-001                                                                                                                                                    |                                   
| Use Case Adı       | Çevre Görevlisi İl Müdürlüğü Uygunluk Başvurusu Oluşturur                                                                                                     |                                   
| Aktörler           | Birincil: Çevre Görevlisiİkincil: ÇDF/ÇYB (onay), Firma Yetkilisi (onay), e-ÇED Sistemi, TOBB/TESK, Sıfır Atık Sistemi                                        |                                   
| Ön Koşullar        | 1. Tesis Hesap Modülü'nde tanımlı olmalıdır2. ÇG tesise yetkili olmalıdır3. Tesisin aktif İl Md. Uygunluk belgesi veya GFB/İzin-Lisans belgesi bulunmamalıdır |                                   
| Başarılı Son Koşul | İl Müdürlüğü Uygunluk başvurusu oluşturulur ve değerlendirmeye gönderilir                                                                                     |  
| Öncelik/Kritiklik | Kritik |                                                                                                                                                                                             
| İlgili İş Kuralları | BR-BSV-001: Başvuru EK-1 ise Bakanlık, EK-2 ise İl Md.'ne yönlendirilirBR-BSV-002: Çoklu onay akışı tanımlı ise tüm onaylar gerekir |                                                            
| İlgili Gereksinimler | FR-BSV-001 - FR-BSV-012 |                                                                                                                                                                       
| Notlar/Varsayımlar | İl Md. Uygunluk yazısı 1 yıl geçerlidir (Md.4-i) |                                 
#### Temel Akış                                                                                                                                                                                                               
| Adım |                                               Açıklama                                                |  
|------|----------------------------------------------------------------------------------------|                                                                                                         
| 1    | ÇG tesis seçer ve "İl Md. Uygunluk Başvurusu" işlemini başlatır                                       |                                                                                                         
| 2    | Sistem başvuru formunu açar (EK-3A formatında)                                                        |                                                                                                         
| 3    | Sistem tesis temel bilgilerini Hesap Modülü'nden otomatik doldurur (Ad, Adres, Koordinat, Vergi No)   |                                                                                                         
| 4    | ÇG tesisin EK kapsamını seçer (EK-1 veya EK-2)                                                        |                                                                                                         
| 5    | Sistem seçilen EK kapsamına göre alt kategorileri listeler                                            |                                                                                                         
| 6    | ÇG faaliyet alt kategorisini ve kapasite bilgilerini girer                                            |                                                                                                         
| 7    | Sistem EK-1/EK-2 eşik kontrolü yapar (kapasite eşiği)                                                 |                                                                                                         
| 8    | ÇG Çevre İzin konularını seçer (Hava Emisyonu, Çevresel Gürültü, Atıksu Deşarjı, Derin Deniz Deşarjı) |                                                                                                         
| 9    | ÇG Çevre Lisans konularını seçer (varsa)                                                              |                                                                                                         
| 10   | Sistem seçilen konulara göre gerekli belge listesini (EK-3B) oluşturur                                |                                                                                                         
| 11   | Sistem entegre sistemlerden veri çeker:                                                               |                                                                                                         
|      | - ÇED Kararı (e-ÇED)                                                                                  |                                                                                                         
|      | - Sicil Gazetesi (TOBB/TESK)                                                                          |                                                                                                         
|      | - Kapasite Raporu (TOBB/TESK)                                                                         |                                                                                                         
|      | - Sıfır Atık Belgesi (Sıfır Atık Bilgi Sistemi)                                                       |                                                                                                         
| 12   | ÇG eksik/güncel olmayan belgeleri yükler                                                              |                                                                                                         
| 13   | ÇG iş akım şeması ve proses özetini oluşturur/yükler                                                  |                                                                                                         
| 14   | ÇG başvuru formunu tamamlar (BEKRA durumu, çalışma bilgileri vb.)                                     |                                                                                                         
| 15   | ÇG "Önizleme" ile başvuruyu kontrol eder                                                              |                                                                                                         
| 16   | ÇG e-imza ile başvuruyu onaylar                                                                       |                                                                                                         
| 17   | Sistem çoklu onay gerekliyse onay sürecini başlatır (ÇDF/ÇYB → Firma Yetkilisi)                       |                                                                                                         
| 18   | Tüm onaylar alındıktan sonra sistem başvuruyu ilgili İl Müdürlüğü'ne yönlendirir                      |                                                                                                         
| 19   | Sistem başvuru numarası oluşturur ve ÇG'ye bildirir                                                   |                                                                                                         
#### Alternatif Akışlar                                                                                                                                                                                                       
| Kod |               Koşul                |                                                                     Akış                                                                      |
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                               
| 4a  | EK-1 ve EK-2 tesisler aynı adreste | 4a1. Sistem uyarı gösterir: "Aynı adreste EK-1 kapsamında tesis bulunmaktadır"4a2. Başvuru otomatik EK-1 kapsamında değerlendirilir (Md.6(2)) |                             
| 7a  | Kapasite EK-1 eşiğini aşıyor       | 7a1. Sistem "EK-1 kapsamında değerlendirilecektir" uyarısı verir7a2. EK-1 olarak işaretlenir                                                  |                             
| 11a | Entegrasyon hatası                 | 11a1. Sistem hata mesajı gösterir11a2. Belgenin manuel yüklenmesi istenir                                                                     |                             
| 12a | Belge havuzundan seçim             | 12a1. ÇG "Havuzdan Seç" tıklar12a2. Daha önce yüklenmiş uygun belgeler listelenir                                                             |                             
#### İstisnalar                                                                                                                                                                                                               
| Kod |         Durum          |                                            Akış                                             |     
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                                                         
| 6a  | Kapasite bilgisi eksik | Sistem hata verir: "Kapasite raporu bilgileri ile uyumsuz"                                  |                                                                                           
| 11b | ÇED kararı yok         | Sistem başvuruyu kabul etmez: "ÇED kararı (Olumlu/Gerekli Değildir/Kapsam Dışı) zorunludur" |                                                                                           
| 16a | e-imza başarısız       | Sistem hata verir ve yeniden deneme ister                                                   |      

### UC-BSV-002: Geçici Faaliyet Belgesi (GFB) Başvurusu Oluşturma                                                                                                                                                            
|        Alan        | Değer                                                                                                                    |  
|--------------------|--------------------------------------------------------------------------------------------------------------------------|                                                                        
| Use Case ID        | UC-BSV-002                                                                                                               |                                                                        
| Use Case Adı       | Çevre Görevlisi Geçici Faaliyet Belgesi Başvurusu Oluşturur                                                              |                                                                        
| Aktörler           | Birincil: Çevre Görevlisiİkincil: ÇDF/ÇYB (onay), Firma Yetkilisi (onay)                                                 |                                                                        
| Ön Koşullar        | 1. Tesisin geçerli İl Md. Uygunluk yazısı bulunmalıdır2. İl Md. Uygunluk yazısı süresi dolmamış olmalıdır (1 yıl içinde) |                                                                        
| Başarılı Son Koşul | GFB başvurusu oluşturulur ve değerlendirmeye gönderilir                                                                  |
| Öncelik/Kritiklik | Kritik                                                                                                                   |                                                                                                                                                                                             
| İlgili İş Kuralları | BR-BSV-020: GFB konuları uygunluk yazısından otomatik gelir, değiştirilemezBR-BSV-021: GFB 1 yıl geçerlidir              |                                                                                    
| İlgili Gereksinimler | FR-BSV-020 - FR-BSV-024 - FR-BSV-026                                                                                                |                                                                                                                                                                       
| Notlar/Varsayımlar | GFB değerlendirme süresi 30 takvim günüdür (Md.8(1))                                                                     |                                                                        
#### Temel Akış                                                                                                                                                                                                               
| Adım | Açıklama                                                                                    |   
|------|---------------------------------------------------------------------------------------------|                                                                                                                 
| 1    | ÇG tesis seçer ve "GFB Başvurusu" işlemini başlatır                                         |                                                                                                                   
| 2    | Sistem İl Md. Uygunluk yazısı geçerliliğini kontrol eder                                  |                                                                                                                   
| 3    | Sistem uygunluk yazısındaki EK kapsamı ve izin/lisans konularını salt okunur olarak getirir |                                                                                                                   
| 4    | Sistem iş akım şeması ve proses özetini uygunluktan otomatik aktarır                        |                                                                                                                   
| 5    | Sistem entegre sistemlerden güncel veri çeker (ÇED, Sicil Gazetesi) todo:     Güncel veri ne                   |                                                                                                                   
| 6    | Sistem EK-3B'de belirtilen GFB özel belgelerini listeler                                    |                                                                                                                   
| 7    | ÇG lisans konularına göre özel belgeleri yükler:                                            |                                                                                                                   
|      | - Teminat Mektubu (atık işleme tesisleri için)                                              |                                                                                                                   
|      | - Tehlikeli Maddeler Mali Sorumluluk Sigortası                                              |                                                                                                                   
|      | - Sterilizasyon Cihazı Uygunluk Belgesi (tıbbi atık tesisleri) vb.                          |                                                                                                                   
| 8    | ÇG başvuru formunu doldurur                                                                 |                                                                                                                   
| 9    | ÇG "Önizleme" ile başvuruyu kontrol eder                                                    |                                                                                                                   
| 10   | ÇG e-imza ile başvuruyu onaylar                                                             |                                                                                                                   
| 11   | Sistem çoklu onay sürecini başlatır (gerekiyorsa)                                           |                                                                                                                   
| 12   | Sistem başvuruyu EK kapsamına göre yönlendirir (EK-1: Bakanlık, EK-2: İl Md.)               |                                                                                                                   
| 13   | Sistem başvuru numarası oluşturur                                                           |                                                                                                                   
#### Alternatif Akışlar                                                                                                                                                                                                       
| Kod |             Koşul             |                                                      Akış                                                       |     
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                              
| 2a  | Uygunluk yazısı süresi dolmuş | Sistem hata verir: "İl Md. Uygunluk yazısı süresi dolmuştur. Yeni uygunluk başvurusu yapılmalıdır."             |                                                                
| 3a  | Konu değişikliği isteniyor    | 3a1. Sistem uyarı verir: "Konu değişikliği için yeni İl Md. Uygunluk başvurusu gereklidir"3a2. İşlem engellenir |                                                                
| 7a  | Belge daha önce yüklenmiş     | 7a1. Sistem geçerli belgeyi gösterir7a2. ÇG belgeyi kullanır veya yenisini yükler                               |                                                                
#### İstisnalar                                                                                                                                                                                                               
| Kod |            Durum             |                                     Akış                                      |   
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                                                                   
| 6a  | Tabi olmadığı konuya başvuru | Sistem uyarı verir ve başvuruyu İl Md. Uygunluk aşamasına iade eder (Md.8(2)) |     

### UC-BSV-003: Çevre İzni/Lisansı Başvurusu Oluşturma                                                                                                                                                                       
|        Alan        | Değer                                                                                                     |
|--------------------|-----------------------------------------------------------------------------------------------------------|                                                                                        
| Use Case ID        | UC-BSV-003                                                                                                |                                                                                       
| Use Case Adı       | Çevre Görevlisi Çevre İzni/Lisansı Başvurusu Oluşturur                                                    |                                                                                       
| Aktörler           | Birincil: Çevre Görevlisiİkincil: ÇDF/ÇYB (onay), Firma Yetkilisi (onay), Ölçüm Sistemleri                |                                                                                       
| Ön Koşullar        | 1. Tesisin geçerli GFB belgesi bulunmalıdır2. GFB tarihinden itibaren 180 gün içinde başvuru yapılmalıdır |                                                                                       
| Başarılı Son Koşul | Çevre İzni/Lisansı başvurusu oluşturulur ve değerlendirmeye gönderilir                                    |  
| Öncelik/Kritiklik | Kritik                                                                                                    |                                                                                                                                                                                             
| İlgili İş Kuralları | BR-BSV-030: İzin/Lisans konuları GFB'den gelirBR-BSV-031: Çevre İzni/Lisansı 5 yıl geçerlidir             |                                                                                                  
| İlgili Gereksinimler | FR-BSV-030 - FR-BSV-034 - FR-BSV-035                                                                                |                                                                                                                                                                       
| Notlar/Varsayımlar | İzin/Lisans değerlendirme süresi 60 takvim günüdür (Md.9(2))                                              |                                                                                     
#### Temel Akış                                                                                                                                                                                                               
| Adım |                                               Açıklama                                               |  
|------|----------------------------------------------------------------------------------------|                                                                                                         
| 1    | ÇG tesis seçer ve "Çevre İzni/Lisansı Başvurusu" işlemini başlatır                                   |                                                                                                          
| 2    | Sistem GFB geçerliliğini ve 180 günlük süreyi kontrol eder                                           |                                                                                                          
| 3    | Sistem GFB'deki izin/lisans konularını salt okunur olarak getirir                                    |                                                                                                          
| 4    | Sistem EK-3C'de belirtilen belge ve bilgileri listeler                                               |                                                                                                          
| 5    | İzin Konuları için:                                                                                  |                                                                                                          
|      | 5.1 Hava Emisyonu: Sistem emisyon ölçüm raporunu ister                                               |                                                                                                          
|      | 5.2 Çevresel Gürültü: Sistem akustik raporu ister                                                    |                                                                                                          
|      | 5.3 Atıksu Deşarjı: Sistem atıksu deşarjı teknik bilgiler listesi ve arıtma tesisi proje onayı ister |                                                                                                          
|      | 5.4 Derin Deniz Deşarjı: Sistem derin deniz deşarjı teknik bilgiler listesi ve proje onayı ister     |                                                                                                          
| 6    | Lisans Konuları için:                                                                                |                                                                                                          
|      | Sistem Teknik Uygunluk Raporu ve İşyeri Açma Ruhsatı ister                                           |                                                                                                          
| 7    | ÇG entegre sistemlerden ölçüm sonuçlarını çeker (HEYGEL, Atıksu Bilgi Sistemi vb.)                   |                                                                                                          
| 8    | Sistem ölçüm sonuçlarını mevzuat sınır değerleriyle karşılaştırır                                    |                                                                                                          
| 9    | Sistem uyumsuzluk varsa uyarı gösterir                                                               |                                                                                                          
| 10   | ÇG tüm belgeleri yükler/seçer                                                                        |                                                                                                          
| 11   | ÇG başvuru formunu doldurur                                                                          |                                                                                                          
| 12   | ÇG "Önizleme" ile başvuruyu kontrol eder                                                             |                                                                                                          
| 13   | ÇG e-imza ile başvuruyu onaylar                                                                      |                                                                                                          
| 14   | Sistem çoklu onay sürecini başlatır (gerekiyorsa)                                                    |                                                                                                          
| 15   | Sistem başvuruyu EK kapsamına göre yönlendirir                                                       |                                                                                                          
| 16   | Sistem başvuru numarası oluşturur                                                                    |                                                                                                          
#### Alternatif Akışlar                                                                                                                                                                                                       
| Kod |                Koşul                |                                                                 Akış                                                                  |
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                      
| 2a  | 180 günlük süre aşılmış             | 2a1. Sistem uyarı verir: "GFB tarihinden itibaren 180 gün geçmiştir"2a2. GFB iptal riski hatırlatılır2a3. Başvuru yine de yapılabilir |                                    
| 8a  | Ölçüm değerleri sınır değeri aşıyor | 8a1. Sistem kırmızı uyarı gösterir8a2. "Değerlendirme sürecinde reddedilebilir" notu eklenir8a3. Başvuru yine de yapılabilir          |                                    
| 7a  | Entegrasyon hatası                  | 7a1. Sistem manuel veri girişi ister7a2. Ölçüm raporu PDF olarak yüklenir                                                             |                                    
#### İstisnalar                                                                                                                                                                                                               
| Kod |        Durum        |                                    Akış                                     |    
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                                                                             
| 2b  | GFB iptal edilmiş   | Sistem hata verir: "GFB iptal edilmiştir. Yeni GFB başvurusu yapılmalıdır." |                                                                                                              
| 10a | Zorunlu belge eksik | Sistem başvuruyu göndermez: "X belgesi zorunludur"                          |                                                                                                              

### UC-BSV-004: Belge Havuzundan Belge Seçme                                                                                                                                                                                 
|        Alan        |                                         Değer                                          |   
|--------------------|-------------------------------------------------------------------------------------------------------------|                                                                                                         
| Use Case ID        | UC-BSV-004                                                                             |                                                                                                          
| Use Case Adı       | Çevre Görevlisi Daha Önce Yüklenmiş Belgeyi Yeniden Kullanır                           |                                                                                                          
| Aktörler           | Birincil: Çevre Görevlisi                                                              |                                                                                                          
| Ön Koşullar        | 1. Başvuru formu açık olmalıdır2. Tesis için daha önce yüklenmiş belgeler bulunmalıdır |                                                                                                          
| Başarılı Son Koşul | Daha önce yüklenmiş belge başvuruya eklenir                                            |      
| Öncelik/Kritiklik | Kritik |                                                                                                                                                                                             
| İlgili İş Kuralları | BR-BSV-004: Belgeler geçerlilik süresi kontrolüne tabi tutulur |                                                                                                                                 
| İlgili Gereksinimler | FR-BSV-009, FR-BLG-021, FR-BLG-022 |                                                                                                                                                            
| Notlar/Varsayımlar | Belge havuzu tesis bazında tutulur |                                                                                                    
#### Temel Akış                                                                                                                                                                                                               
| Adım |                                               Açıklama                                                |  
|------|----------------------------------------------------------------------------------------|                                                                                                         
| 1    | ÇG başvuru formunda belge yükleme alanına gelir                                                       |                                                                                                         
| 2    | ÇG "Havuzdan Seç" butonuna tıklar                                                                     |                                                                                                         
| 3    | Sistem tesis için daha önce yüklenmiş belgeleri listeler                                              |                                                                                                         
| 4    | Sistem her belge için: dosya adı, yükleme tarihi, kullanıldığı başvurular, geçerlilik durumu gösterir |                                                                                                         
| 5    | Sistem geçersiz/süresi dolmuş belgeleri pasif gösterir                                                |                                                                                                         
| 6    | ÇG uygun belgeyi seçer                                                                                |                                                                                                         
| 7    | Sistem belgenin bu başvuru için uygun olup olmadığını kontrol eder                                    |                                                                                                         
| 8    | Sistem belgeyi başvuruya ekler                                                                        |                                                                                                         
| 9    | ÇG gerekirse belge üzerine açıklama ekler                                                             |                                                                                                         
#### Alternatif Akışlar                                                                                                                                                                                                       
| Kod |               Koşul               |                                     Akış                                     |  
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                                                                
| 5a  | Tüm belgeler geçersiz             | Sistem "Uygun belge bulunamadı. Lütfen yeni belge yükleyin." mesajı gösterir |                                                                                               
| 7a  | Belge bu başvuru için uygun değil | Sistem uyarı verir: "Bu belge X başvuru tipi için uygun değildir"            |                                                                                               

### UC-BSV-005: İş Akım Şeması ve Proses Özeti Oluşturma                                                                                                                                                                     
|        Alan        |                          Değer                           |    
|--------------------|-------------------------------------------------------------------------------------------------------------|                                                                                                                                       
| Use Case ID        | UC-BSV-005                                               |                                                                                                                                        
| Use Case Adı       | Çevre Görevlisi İş Akım Şeması ve Proses Özeti Oluşturur |                                                                                                                                        
| Aktörler           | Birincil: Çevre Görevlisi                                |                                                                                                                                        
| Ön Koşullar        | 1. İl Md. Uygunluk başvurusu açık olmalıdır              |                                                                                                                                        
| Başarılı Son Koşul | İş akım şeması ve proses özeti başvuruya eklenir         |       
| Öncelik/Kritiklik | Kritik |                                                                                                                                                                                             
| İlgili İş Kuralları | BR-BSV-005: Proses özeti tüm üretim aşamalarını ve atık kaynaklarını içermelidir |                                                                                                               
| İlgili Gereksinimler | FR-BSV-010, FR-BSV-040, FR-BSV-041, FR-BSV-042, FR-BSV-043, FR-BSV-044, FR-BSV-045, FR-BSV-046, FR-BSV-047, FR-BSV-048, FR-BSV-049, FR-BSV-050, FR-BSV-051, FR-BSV-052, FR-BSV-053, FR-BSV-054, EK-3B |                                                                                                                                                                             
| Notlar/Varsayımlar | Proses özeti GFB ve İzin/Lisans başvurularında kullanılmak üzere taşınır |                                                                                                                                 
#### Temel Akış
| Adım |                              Açıklama                               |
|------|----------------------------------------------------------------------------------------|
| 1    | ÇG başvuru formunda "İş Akım Şeması ve Proses Özeti" bölümüne gelir |
| 2    | Sistem iki seçenek sunar: "Sistemde Oluştur" veya "Dosya Yükle"     |
| 3    | ÇG "Sistemde Oluştur" seçer                                         |
| 4    | Sistem proses özeti editörünü açar                                  |
| 5    | **Bölüm 1 - İşletme Bilgileri:** ÇG işletme lokasyon bilgilerini girer (il, ilçe, mahalle, pafta, ada, parsel, alan m²) |
| 6    | **Bölüm 2 - Faaliyetler:** ÇG faaliyet/faaliyetleri tanımlar (çoklu faaliyet desteklenir) |
| 7    | **Bölüm 3 - Vaziyet Planları ve Üniteler:** |
|      | 7a. ÇG genel vaziyet planını yükler |
|      | 7b. Her ünite için: |
|      |     - Ünite adı ve vaziyet planı |
|      |     - Alan bilgileri (m², kapalı/açık alan) |
|      |     - Gerçekleştirilen işlemler |
|      |     - İş akım şeması (adım adım açıklama ile) |
|      |     - Kullanılan ekipmanlar |
|      |     - Girdi/çıktılar |
| 8    | **Bölüm 4 - Atıklar:** |
|      | 8a. İşletmeye kabul edilecek atık kodları (tehlikeli atık geri kazanımı, ambalaj atığı geri dönüşümü vb. kategorilerde) |
|      | 8b. Tesisten oluşacak atık kodları |
| 9    | **Bölüm 5 - Hava Emisyonları:** ÇG hava emisyon kaynaklarını ve alınan önlemleri tanımlar |
| 10   | **Bölüm 6 - Atıksu Deşarjı:** |
|      | 10a. Atıksu türü (evsel/endüstriyel), arıtma türü, alıcı ortam, deşarj miktarı |
|      | 10b. Atıksu arıtma tesisi bilgileri (kapasite, sektör türü, SKKY tablo numarası) |
|      | 10c. Su kullanım bilgileri (soğutma, proses, kullanma suyu) - amaç, kaynak, miktar, geri kullanım durumu |
|      | 10d. Atıksu arıtma tesisi akım şeması yükleme |
|      | 10e. Arıtma çamuru miktarı ve bertaraf yöntemi |
|      | 10f. SAİS kapsamı kontrolü (>=10.000 m³/gün tesisler için SAİS Proje Onay Yazısı zorunlu) |
| 11   | **Bölüm 7 - Fotoğraflar:** ÇG tesis fotoğraflarını yükler (dış görünüş, iç görünüş, ünite/makine/ekipman) |
| 12   | ÇG "Kaydet" butonuna tıklar                                         |
| 13   | Sistem proses özetini PDF formatında oluşturur ve başvuruya ekler   |                                                                                                                                           
#### Alternatif Akışlar                                                                                                                                                                                                       
| Kod |            Koşul            |                                                   Akış                                                    |   
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                                        
| 3a  | Dosya yükleme tercih edilir | 3a1. ÇG "Dosya Yükle" seçer3a2. PDF/Word formatında hazır doküman yükler3a3. Sistem format kontrolü yapar |






## MODÜL 9: GÖRÜŞ VE ÖZEL İŞLEMLER (OZL)

### UC-OZL-001: Görüş Talebi Oluşturma
|        Alan        |                                                        Değer                                                        |
|--------------------|---------------------------------------------------------------------------------------------------------------------|
| Use Case ID        | UC-OZL-001                                                                                                          |
| Use Case Adı       | Çevre Görevlisi İzin/Lisans Belgesine İlişkin Görüş Talebinde Bulunur                                              |
| Aktörler           | Birincil: Çevre Görevlisi (ÇG)İkincil: Bakanlık Personeli                                                           |
| Ön Koşullar        | 1. Tesis sisteme kayıtlı olmalıdır2. ÇG tesis adına işlem yetkisine sahip olmalıdır                                 |
| Başarılı Son Koşul | Görüş talebi oluşturulur ve Bakanlık'a iletilir                                                                    |
| Öncelik/Kritiklik | Orta |
| İlgili İş Kuralları | BR-OZL-001: Görüş talepleri Bakanlık tarafından değerlendirilir (Şartname 9.5.9.2) |
| İlgili Gereksinimler | FR-OZL-001, FR-OZL-002 |
#### Temel Akış
| Adım |                              Açıklama                               |
|------|----------------------------------------------------------------------|
| 1    | ÇG tesis seçer ve "Görüş Talebi" işlemini başlatır                  |
| 2    | Sistem görüş talebi türlerini listeler:                              |
|      | a) İzin/Lisans belgesine ilişkin görüş                               |
|      | b) Belge yenileme gerekliliğine ilişkin görüş                        |
| 3    | ÇG görüş talebi türünü seçer                                        | 
| 4    | Sistem görüş talebi formunu açar                                     | todo: formda hangi veriler var?
| 5    | ÇG görüş talebi konusunu ve detaylarını girer                        |
| 6    | ÇG varsa destekleyici belgeleri yükler                               |
| 7    | ÇG e-imza ile görüş talebini gönderir                                |
| 8    | Sistem talebi Bakanlık'a yönlendirir                                 |
| 9    | Sistem ÇG'ye talep oluşturuldu bildirimi gönderir                    |
#### Alternatif Akışlar
| Kod |               Koşul                |                                 Akış                                 |
|-----|-------------------------------------|----------------------------------------------------------------------|
| 5a  | Mevcut İzin/Lisans belgesi yoksa    | 5a1. Sistem uyarı verir: "Tesis için aktif İzin/Lisans belgesi bulunamadı" |
| 7a  | e-İmza doğrulama başarısız          | 7a1. Sistem hata mesajı gösterir7a2. ÇG tekrar dener                 | //todo: e imza burda da mı olacak?

### UC-OZL-002: Görüş Talebini Değerlendirme ve Yanıtlama
|        Alan        |                                                        Değer                                                        |
|--------------------|---------------------------------------------------------------------------------------------------------------------|
| Use Case ID        | UC-OZL-002                                                                                                          |
| Use Case Adı       | Bakanlık Personeli Görüş Talebini Değerlendirir ve Yanıtlar                                                         |
| Aktörler           | Birincil: Bakanlık Personeli, Şube Müdürüİkincil: Çevre Görevlisi                                                   |
| Ön Koşullar        | 1. Görüş talebi sisteme kayıtlı olmalıdır2. Talep Bakanlık'a yönlendirilmiş olmalıdır                               |
| Başarılı Son Koşul | Görüş yanıtı hazırlanır, imzalanır ve talep sahibine iletilir                                                       |
| Öncelik/Kritiklik | Orta |
| İlgili İş Kuralları | BR-OZL-002: Görüş yanıtları tanımlı şablonlar kullanılarak hazırlanır ve imza akışına sunulur (Şartname 9.5.9.2) |
| İlgili Gereksinimler | FR-OZL-003, FR-OZL-004 |
#### Temel Akış
| Adım |                              Açıklama                               |
|------|----------------------------------------------------------------------|
| 1    | Bakanlık Personeli görüş talebi listesinden bir talebi seçer         |
| 2    | Sistem talep detaylarını ve ilgili belgeleri gösterir                 |
| 3    | Personel talebi inceler ve değerlendirme yapar                       | //todo: degerlendirme kriterleri
| 4    | Personel tanımlı görüş şablonlarından uygun olanı seçer              | 
| 5    | Personel görüş yazısı içeriğini düzenler                             |
| 6    | Personel görüş yazısını imza akışına sunar                           |
| 7    | Şube Müdürü görüş yazısını inceler ve onaylar                        |
| 8    | Sistem onaylanan görüş yazısını e-imza ile imzalar (Belgenet)        | 
| 9    | Sistem görüş yanıtını talep sahibi ÇG'ye bildirim olarak iletir     |
| 10   | Sistem görüş yanıt süresini kaydeder                                 | 
#### Alternatif Akışlar
| Kod |               Koşul                |                                 Akış                                 |
|-----|-------------------------------------|----------------------------------------------------------------------|
| 7a  | Şube Müdürü düzeltme ister          | 7a1. Yazı personele iade edilir7a2. Personel düzeltme yapar ve tekrar sunar |
| 4a  | Uygun şablon bulunamazsa            | 4a1. Personel serbest metin olarak görüş yazısı hazırlar             |

### UC-OZL-003: ÖFB Kayıt İşlemi Yapma
|        Alan        |                                                        Değer                                                        |
|--------------------|---------------------------------------------------------------------------------------------------------------------|
| Use Case ID        | UC-OZL-003                                                                                                          |
| Use Case Adı       | Yetkili Personel Özel Faaliyet Belgesi (ÖFB) Kaydı Oluşturur                                                       |
| Aktörler           | Birincil: Bakanlık Personeli, İl Müdürlüğü Personeli                                                                |
| Ön Koşullar        | 1. ÖFB tip şablonu tanımlı olmalıdır2. Tesis sisteme kayıtlı olmalıdır                                              |
| Başarılı Son Koşul | ÖFB kaydı oluşturulur ve tesis ile ilişkilendirilir                                                                 |
| Öncelik/Kritiklik | Orta |
| İlgili İş Kuralları | BR-OZL-003: ÖFB kayıt işlemleri yetkili personel tarafından gerçekleştirilir (Şartname 9.5.12.2) |
| İlgili Gereksinimler | FR-OZL-010, FR-OZL-014 |
#### Temel Akış
| Adım |                              Açıklama                               |
|------|----------------------------------------------------------------------|
| 1    | Yetkili personel "ÖFB Kayıt" işlemini başlatır                       |
| 2    | Sistem kayıtlı ÖFB tiplerini listeler                                |
| 3    | Personel uygun ÖFB tipini seçer                                      |
| 4    | Sistem seçilen tipe göre kayıt formunu açar                          |
| 5    | Personel tesis bilgilerini seçer/girer                                |
| 6    | Personel ÖFB kapsamındaki bilgileri girer:                            |
|      | a) Atık kodları                                                      |
|      | b) İşleme yöntemleri                                                 |
|      | c) Kapasite bilgileri                                                |
| 7    | Personel gerekli belgeleri yükler                                    |
| 8    | Sistem girilen bilgileri doğrular                                    |
| 9    | Personel kaydı onaylar                                               |
| 10   | Sistem ÖFB kaydını oluşturur ve tesis ile ilişkilendirir             |
#### Alternatif Akışlar
| Kod |               Koşul                |                                 Akış                                 |
|-----|-------------------------------------|----------------------------------------------------------------------|
| 8a  | Doğrulama hatası oluşursa           | 8a1. Sistem hata mesajları gösterir8a2. Personel düzeltme yapar      |
| 3a  | Uygun ÖFB tipi bulunamazsa          | 3a1. Personel yeni ÖFB tipi tanımlama sürecini başlatır (UC-OZL-004) |

### UC-OZL-004: ÖFB Şablon ve Versiyon Yönetimi
|        Alan        |                                                        Değer                                                        |
|--------------------|---------------------------------------------------------------------------------------------------------------------|
| Use Case ID        | UC-OZL-004                                                                                                          |
| Use Case Adı       | Sistem Yöneticisi ÖFB Tip Şablonlarını Yönetir ve Versiyonları İzler                                               |
| Aktörler           | Birincil: Sistem Yöneticisi                                                                                         |
| Ön Koşullar        | 1. Kullanıcı sistem yöneticisi rolüne sahip olmalıdır                                                               |
| Başarılı Son Koşul | ÖFB tip şablonu oluşturulur/güncellenir ve versiyonlanır                                                            |
| Öncelik/Kritiklik | Orta |
| İlgili İş Kuralları | BR-OZL-004: ÖFB şablonları versiyonlanır, yeni tipler eklenebilir yapıda olmalıdır (Şartname 9.5.12.3, 9.5.12.4) |
| İlgili Gereksinimler | FR-SYS-033, FR-OZL-011, FR-OZL-012, FR-OZL-013 |
#### Temel Akış
| Adım |                              Açıklama                               |
|------|----------------------------------------------------------------------| 
| 1    | Sistem Yöneticisi "ÖFB Şablon Yönetimi" ekranını açar               | todo: bu sys içindeki belge şablonu mu?
| 2    | Sistem mevcut ÖFB tip şablonlarını listeler                          |
| 3    | Yönetici yeni şablon oluşturma veya mevcut şablonu güncelleme seçer  |
| 4    | Yeni şablon için:                                                    |
|      | 4a. ÖFB tip adı ve açıklaması girilir                                |
|      | 4b. Gerekli alan tanımları yapılır (atık kodları, işleme yöntemleri) |
|      | 4c. Belge gereksinimleri tanımlanır                                  |
| 5    | Güncelleme için:                                                     |
|      | 5a. Mevcut şablon seçilir                                            |
|      | 5b. Değişiklikler yapılır                                            |
|      | 5c. Sistem yeni versiyonu otomatik oluşturur                         |
| 6    | Sistem versiyon farkını gösterir (atık kodu, işleme yöntemi farkları)|
| 7    | Yönetici değişiklikleri onaylar                                      |
| 8    | Sistem şablonu kaydeder ve versiyon numarasını artırır               |
#### Alternatif Akışlar
| Kod |               Koşul                |                                 Akış                                 |
|-----|-------------------------------------|----------------------------------------------------------------------|
| 5d  | Şablon aktif ÖFB kayıtlarında kullanılıyorsa | 5d1. Sistem uyarı verir: "Bu şablon aktif kayıtlarda kullanılmaktadır"5d2. Değişiklikler yalnızca yeni kayıtları etkiler |
| 3a  | Şablon silinmek istenirse           | 3a1. Sistem aktif kullanım kontrolü yapar3a2. Aktif kullanım yoksa pasif duruma alır |

### UC-OZL-005: Belge Askıya Alma ve Askı Kaldırma // todo: bu belge başvuru sürecinde oluşturulan belge mi? basvuru sürecinde yüklenen belge mi yoksa tesise özel yüklenen belge mi
|        Alan        |                                                        Değer                                                        |
|--------------------|---------------------------------------------------------------------------------------------------------------------|
| Use Case ID        | UC-OZL-005                                                                                                          |
| Use Case Adı       | Yetkili Kullanıcı Tesis Belgesini Lisans Konularına Yönelik Askıya Alır veya Askıyı Kaldırır                       |
| Aktörler           | Birincil: İl Müdürlüğü Personeli, Bakanlık Personeli                                                                |
| Ön Koşullar        | 1. Tesisin geçerli İzin/Lisans belgesi olmalıdır2. Askıya alma gerekçesi mevcut olmalıdır                           |
| Başarılı Son Koşul | Belge askıya alınır/askıdan kaldırılır ve ilgililer bilgilendirilir                                                 |
| Öncelik/Kritiklik | Yüksek |
| İlgili İş Kuralları | BR-OZL-005: Askıya alma süresi belirlenmeli ve gerekçe girilmelidir (Şartname 9.5.1.7) |
| İlgili Gereksinimler | FR-OZL-020, FR-OZL-021, FR-OZL-022, FR-OZL-023 |
#### Temel Akış
| Adım |                              Açıklama                               |
|------|----------------------------------------------------------------------|
| 1    | Yetkili personel tesis belge detay ekranını açar                     |
| 2    | Personel "Askıya Al" işlemini seçer                                  |
| 3    | Sistem askıya alınabilecek lisans konularını listeler                 |
| 4    | Personel askıya alınacak lisans konularını seçer                     |
| 5    | Personel askıya alma gerekçesini girer (zorunlu alan)                |
| 6    | Personel askı süresini belirler (başlangıç-bitiş tarihi)            |
| 7    | Personel askı süresi sonunda otomatik aktifleştirme veya manuel onay tercihini seçer |
| 8    | Personel işlemi onaylar                                              |
| 9    | Sistem seçilen lisans konularını askıya alır                         | todo: hangi personel. uzmana filan mı atanacak?
| 10   | Sistem ÇG ve Firma Yetkilisine bildirim gönderir                    | //todo: manuel bildirim mi otomatik  
| 11   | Sistem askıya alma kaydını oluşturur (tarih, gerekçe, süre, personel)|
#### Alternatif Akışlar
| Kod |               Koşul                |                                 Akış                                 |
|-----|-------------------------------------|----------------------------------------------------------------------|
| A1  | Askı süresi dolduğunda (otomatik)   | A1.1. Sistem askı süresini kontrol ederA1.2. Otomatik aktifleştirme seçili ise belgeyi aktif duruma geçirirA1.3. Manuel onay seçili ise personele bildirim gönderir |
| A2  | Personel askıyı erken kaldırmak ister | A2.1. Personel "Askıyı Kaldır" işlemini seçerA2.2. Kaldırma gerekçesini girerA2.3. Sistem belgeyi aktif duruma geçirirA2.4. İlgililere bildirim gönderilir |
| 5a  | Gerekçe girilmezse                  | 5a1. Sistem uyarı verir: "Askıya alma gerekçesi zorunludur"         |

---

## MODÜL 10: BELGE YÖNETİMİ (BLG)

### UC-BLG-001: Belge Oluşturma ve ÇKN Atama                                                                                                                                                                                 
|        Alan        |                                    Değer                                    |   
|--------------------|-------------------------------------------------------------------------------------------------------------|                                                                                                                     
| Use Case ID        | UC-BLG-001                                                                  |                                                                                                                     
| Use Case Adı       | Sistem Onaylanan Başvuru İçin Belge Oluşturur ve ÇKN Atar                   |                                                                                                                     
| Aktörler           | Birincil: Sistem (otomatik)                                                 |                                                                                                                     
| Ön Koşullar        | 1. Başvuru "Uygun" kararı almış olmalıdır2. Belge şablonu tanımlı olmalıdır |                                                                                                                     
| Başarılı Son Koşul | Belge oluşturulur, benzersiz ÇKN atanır                                     |   
| Öncelik/Kritiklik | Kritik |                                                                                                                                                                                             
| İlgili İş Kuralları | BR-BLG-001: Her belge benzersiz ÇKN'ye sahip olmalıdır |                                                                                                                                         
| İlgili Gereksinimler | FR-BLG-001, FR-BLG-002, FR-BLG-003, FR-BLG-004 |                                                                                                                  
#### Temel Akış                                                                                                                                                                                                               
| Adım |                         Açıklama                          |    
|------|----------------------------------------------------------------------------------------|                                                                                                                                                  
| 1    | Değerlendirici "Uygun" kararı verir                       |                                                                                                                                                     
| 2    | Sistem belge tipine göre aktif şablonu seçer              |                                                                                                                                                     
| 3    | Sistem benzersiz ÇKN (Çevresel Kayıt Numarası) oluşturur: |                                                                                                                                                     
|      | Format: [Belge Tipi]-[Yıl]-[Sıra No]                      |                                                                                                                                                     
|      | Örnek: GFB-2026-000123, IL-2026-000456                    |                                                                                                                                                     
| 4    | Sistem şablondaki dinamik alanları doldurur               |                                                                                                                                                     
| 5    | Sistem geçerlilik tarihlerini hesaplar:                   |                                                                                                                                                     
|      | - İl Md. Uygunluk: 1 yıl                                  |                                                                                                                                                     
|      | - GFB: 1 yıl                                              |                                                                                                                                                     
|      | - İzin/Lisans: 5 yıl                                      |                                                                                                                                                     
| 6    | Sistem belgeyi PDF formatında oluşturur                   |                                                                                                                                                     
| 7    | Sistem belgeye dijital damga (watermark) ekler            |                                                                                                                                                     
| 8    | Sistem belgeyi veritabanına kaydeder                      |                                                                                                                                                     
| 9    | Sistem önceki belgelerle ilişkilendirir (varsa)           |                                                                                                                                                     

### UC-BLG-002: Belge Versiyonlama                                                                                                                                                                                           
|        Alan        |                                          Değer                                          |   
|--------------------|-------------------------------------------------------------------------------------------------------------|                                                                                                        
| Use Case ID        | UC-BLG-002                                                                              |                                                                                                         
| Use Case Adı       | Sistem Belge Versiyonlarını Yönetir                                                     |                                                                                                         
| Aktörler           | Birincil: Sistem (otomatik)                                                             |                                                                                                         
| Ön Koşullar        | 1. Tesis için daha önce belge düzenlenmiş olmalıdır2. Yeni belge oluşturulmuş olmalıdır |                                                                                                         
| Başarılı Son Koşul | Belge zincirleme yapılır, versiyon geçmişi tutulur                                      |   
| Öncelik/Kritiklik | Kritik |                                                                                                                                                                                             
| İlgili İş Kuralları | BR-BLG-002: Her yeni belge öncekinin devamı niteliğindedir (Md.9(4)) |                                                                                                                           
| İlgili Gereksinimler | FR-BLG-005, FR-BLG-010, FR-BLG-011, FR-BLG-013, FR-BLG-014 |                                                                                                      
#### Temel Akış                                                                                                                                                                                                               
| Adım |                          Açıklama                           |  
|------|----------------------------------------------------------------------------------------|                                                                                                                                                  
| 1    | Yeni belge oluşturulur (yenileme, güncelleme)               |                                                                                                                                                   
| 2    | Sistem tesis için önceki belgeleri kontrol eder             |                                                                                                                                                   
| 3    | Sistem yeni belgeyi önceki belgenin devamı olarak işaretler |                                                                                                                                                   
| 4    | Sistem versiyon numarası atar (V1, V2, V3...)               |                                                                                                                                                   
| 5    | Sistem önceki belgeyi "Pasif - Yenilendi" statüsüne geçirir |                                                                                                                                                   
| 6    | Sistem belge zincirini oluşturur:                           |                                                                                                                                                   
|      | Belge A (V1) → Belge B (V2) → Belge C (V3)                  |                                                                                                                                                   
| 7    | Sistem değişiklik nedenini kaydeder:                        |                                                                                                                                                   
|      | - Süre bitimi yenileme                                      |                                                                                                                                                   
|      | - Faaliyet değişikliği                                      |                                                                                                                                                   
|      | - Unvan değişikliği                                         |                                                                                                                                                   
|      | - Konu ekleme/çıkarma                                       |                                                                                                                                                   
| 8    | Sistem geçerli belgeyi (son versiyon) net olarak işaretler  |                                                                                                                                                   

### UC-BLG-003: Belge Geçmişini Görüntüleme                                                                                                                                                                                  
|        Alan        |                          Değer                          |   
|--------------------|-------------------------------------------------------------------------------------------------------------|                                                                                                                                        
| Use Case ID        | UC-BLG-003                                              |                                                                                                                                         
| Use Case Adı       | Kullanıcı Tesisin Belge Geçmişini Kronolojik Görüntüler |                                                                                                                                         
| Aktörler           | Birincil: Çevre Görevlisi, Değerlendirici Personel      |                                                                                                                                         
| Ön Koşullar        | 1. Kullanıcı tesise erişim yetkisine sahip olmalıdır    |                                                                                                                                         
| Başarılı Son Koşul | Belge geçmişi kronolojik olarak görüntülenir            |        
| Öncelik/Kritiklik | Kritik |                                                                                                                                                                                             
| İlgili Gereksinimler | FR-BLG-011, FR-BLG-012, FR-BLG-013 |                                                                                                                                 
#### Temel Akış                                                                                                                                                                                                               
| Adım |                            Açıklama                             |  
|------|----------------------------------------------------------------------------------------|                                                                                                                                              
| 1    | Kullanıcı tesis detay sayfasını açar                            |                                                                                                                                               
| 2    | Kullanıcı "Belge Geçmişi" sekmesine tıklar                      |                                                                                                                                               
| 3    | Sistem tüm belge versiyonlarını zaman çizelgesi olarak gösterir |                                                                                                                                               
| 4    | Her belge için gösterilir:                                      |                                                                                                                                               
|      | - ÇKN                                                           |                                                                                                                                               
|      | - Belge Tipi (Uygunluk, GFB, İzin/Lisans)                       |                                                                                                                                               
|      | - Versiyon Numarası                                             |                                                                                                                                               
|      | - Düzenleme Tarihi                                              |                                                                                                                                               
|      | - Geçerlilik Tarihleri                                          |                                                                                                                                               
|      | - Durum (Geçerli, Pasif, İptal)                                 |                                                                                                                                               
|      | - Değişiklik Nedeni                                             |                                                                                                                                               
| 5    | Kullanıcı bir belgeye tıklayarak detay görür                    |                                                                                                                                               
| 6    | Kullanıcı belgeyi PDF olarak indirebilir                        |                                                                                                                                               
| 7    | İptal edilen belgeler "İPTAL" damgası ile gösterilir            |                                                                                                                                               

### UC-BLG-004: Belge Doğrulama (Kamuya Açık)                                                                                                                                                                                
|        Alan        |                            Değer                             |  
|--------------------|-------------------------------------------------------------------------------------------------------------|                                                                                                                                    
| Use Case ID        | UC-BLG-004                                                   |                                                                                                                                    
| Use Case Adı       | Dış Kullanıcı ÇKN ile Belge Doğrulaması Yapar                |                                                                                                                                    
| Aktörler           | Birincil: Dış Kullanıcı (giriş gerektirmez)                  |                                                                                                                                    
| Ön Koşullar        | 1. Doğrulanacak belgenin ÇKN'si bilinmelidir                 |                                                                                                                                    
| Başarılı Son Koşul | Belge geçerliliği doğrulanır veya geçersiz olduğu bildirilir |  
| Öncelik/Kritiklik | Kritik |                                                                                                                                                                                             
| İlgili İş Kuralları | BR-BLG-004: Doğrulama sayfası giriş gerektirmez |                                                                                                                                                
| İlgili Gereksinimler | Genel kullanılabilirlik gereksinimi |                                                                                                                                  
#### Temel Akış                                                                                                                                                                                                               
| Adım |                             Açıklama                              |
|------|----------------------------------------------------------------------------------------|                                                                                                                                              
| 1    | Kullanıcı e-İzin kamuya açık doğrulama sayfasına erişir           |                                                                                                                                             
| 2    | Kullanıcı ÇKN numarasını girer                                    |                                                                                                                                             
| 3    | Kullanıcı güvenlik doğrulamasını (CAPTCHA) geçer                  |                                                                                                                                             
| 4    | Kullanıcı "Doğrula" butonuna tıklar                               |                                                                                                                                             
| 5    | Sistem ÇKN ile belgeyi arar                                       |                                                                                                                                             
| 6    | Belge bulunursa:                                                  |                                                                                                                                             
|      | 6a. Belge özet bilgileri gösterilir:                              |                                                                                                                                             
|      | - Tesis Adı                                                       |                                                                                                                                             
|      | - Belge Tipi                                                      |                                                                                                                                             
|      | - Düzenleme Tarihi                                                |                                                                                                                                             
|      | - Geçerlilik Durumu                                               |                                                                                                                                             
|      | - İzin/Lisans Konuları                                            |                                                                                                                                             
|      | 6b. "Bu belge geçerlidir" veya "Bu belge iptal edilmiştir" mesajı |                                                                                                                                             
| 7    | Belge bulunamazsa:                                                |                                                                                                                                             
|      | 7a. "Bu ÇKN ile kayıtlı belge bulunamamıştır" mesajı              |                                                                                                                                             

### UC-BLG-005: Belge Arşivleme ve Uzun Vadeli Saklama                                                                                                                                                                       
|        Alan        |                        Değer                        |  
|--------------------|-------------------------------------------------------------------------------------------------------------|                                                                                                                                             
| Use Case ID        | UC-BLG-005                                          |                                                                                                                                             
| Use Case Adı       | Sistem Belgeleri Uzun Vadeli Arşivler               |                                                                                                                                             
| Aktörler           | Birincil: Sistem (otomatik)                         |                                                                                                                                             
| Ön Koşullar        | 1. Belge oluşturulmuş olmalıdır                     |                                                                                                                                             
| Başarılı Son Koşul | Belgeler güvenli ve erişilebilir şekilde arşivlenir |  
| Öncelik/Kritiklik | Kritik |                                                                                                                                                                                             
| İlgili İş Kuralları | BR-BLG-005: Belgeler en az 10 yıl saklanmalıdır |                                                                                                                                                
| İlgili Gereksinimler | FR-BLG-020 |                                                                                                                                           
#### Temel Akış                                                                                                                                                                                                               
| Adım |                              Açıklama                               |  
|------|----------------------------------------------------------------------------------------|                                                                                                                                          
| 1    | Belge imzalanır ve geçerli hale gelir                               |                                                                                                                                           
| 2    | Sistem belgeyi birincil depolama alanına kaydeder                   |                                                                                                                                           
| 3    | Sistem belgeyi arşiv depolama alanına yedekler                      |                                                                                                                                           
| 4    | Sistem meta verileri indeksler:                                     |                                                                                                                                           
|      | - ÇKN, Tesis ID, Tarihler, Konular                                  |                                                                                                                                           
| 5    | Sistem düzenli aralıklarla bütünlük kontrolü yapar (hash doğrulama) |                                                                                                                                           
| 6    | Belge yasal saklama süresince (10+ yıl) erişilebilir tutulur        |                                                                                                                                           
| 7    | Saklama süresi dolan belgeler için silme politikası uygulanır       |                                                                                                                                           
                                                                                                                                                                                                                           
---                                                                                                                                                                                                                      
## MODÜL 11: RAPORLAMA VE ANALİTİK (RPR)

### UC-RPR-001: Yönetici Dashboard Görüntüleme                                                                                                                                                                               
|        Alan        |                             Değer                             |   
|--------------------|------------------------------------------------------------------------------------------------------------|                                                                                                                                  
| Use Case ID        | UC-RPR-001                                                    |                                                                                                                                  
| Use Case Adı       | Üst Yönetici Karar Destek Dashboard'unu Görüntüler            |                                                                                                                                  
| Aktörler           | Birincil: Bakanlık Üst Yöneticisi, İl Müdürü                  |                                                                                                                                  
| Ön Koşullar        | 1. Kullanıcı "Dashboard Görüntüleme" yetkisine sahip olmalıdır |                                                                                                                                  
| Başarılı Son Koşul | Anlık veriler görselleştirilmiş olarak sunulur                | 
| Öncelik/Kritiklik | Kritik |                                                                                                                                                                                             
| İlgili Gereksinimler | FR-RPR-001, FR-RPR-002, FR-RPR-003, FR-RPR-054 |                                                                                                                                 
#### Temel Akış                                                                                                                                                                                                               
| Adım |                       Açıklama                       |  
|------|----------------------------------------------------------------------------------------|                                                                                                                                                         
| 1    | Yönetici sisteme giriş yapar                         |                                                                                                                                                          
| 2    | Sistem otomatik olarak dashboard sayfasını açar      |                                                                                                                                                          
| 3    | Sistem anlık sayaçları gösterir:                     |                                                                                                                                                          
|      | - Toplam Geçerli Belge Sayısı                        |                                                                                                                                                          
|      | - Bekleyen Başvuru Sayısı                            |                                                                                                                                                          
|      | - Bu Ay Düzenlenen Belgeler                          |                                                                                                                                                          
|      | - Yaklaşan Süre Bitimi (30 gün içinde)               |                                                                                                                                                          
| 4    | Sistem grafikleri gösterir:                          |                                                                                                                                                          
|      | - Aylık başvuru trendi (çizgi grafik)                |                                                                                                                                                          
|      | - İl bazlı dağılım (pasta grafik)                    |                                                                                                                                                          
|      | - EK kapsamı dağılımı (çubuk grafik)                 |                                                                                                                                                          
| 5    | Sistem harita görünümünü gösterir:                   |                                                                                                                                                          
|      | - Tesislerin coğrafi dağılımı                        |                                                                                                                                                          
|      | - Bölgesel yoğunluk (ısı haritası)                   |                                                                                                                                                          
| 6    | Sistem uyarı panelini gösterir:                      |                                                                                                                                                          
|      | - Süre aşımı riski olan başvurular                   |                                                                                                                                                          
|      | - Kural ihlali tespitleri                            |                                                                                                                                                          
| 7    | Yönetici filtre seçenekleriyle görünümü özelleştirir |                                                                                                                                                          
#### Alternatif Akışlar                                                                                                                                                                                                       
| Kod |        Koşul        |                                Akış                                 |
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                                                                                        
| 7a  | İl bazlı filtreleme | 7a1. Yönetici il seçer7a2. Tüm veriler seçilen ile göre filtrelenir |                                                                                                                      

### UC-RPR-002: Harita Üzerinden CBS Tabanlı Raporlama                                                                                                                                                                       
| Alan                 | Değer                                                                                    |
|----------------------|------------------------------------------------------------------------------------------|                                                                                                         
| Use Case ID          | UC-RPR-002                                                                               |                                                                                                        
| Use Case Adı         | Kullanıcı Harita Üzerinden Tesis ve Belge Analizi Yapar                                  |                                                                                                        
| Aktörler             | Birincil: Değerlendirici Personel, Yönetici                                              |                                                                                                        
| Ön Koşullar          | 1. ATLAS entegrasyonu aktif olmalıdır2. Tesislerin koordinat bilgileri kayıtlı olmalıdır |                                                                                                        
| Başarılı Son Koşul   | Coğrafi bazlı analiz ve raporlama yapılır                                                |  
| Öncelik/Kritiklik    | Kritik                                                                                   |                                                                                                                                                                                             
| İlgili Gereksinimler | FR-RPR-010, FR-RPR-011, FR-RPR-012, FR-RPR-013, FR-ENT-003                               |                                                                                                      
#### Temel Akış                                                                                                                                                                                                               
| Adım |                        Açıklama                         |      
|------|----------------------------------------------------------------------------------------|                                                                                                                                                  
| 1    | Kullanıcı "Raporlama > Harita Görünümü" menüsünü açar   |                                                                                                                                                       
| 2    | Sistem ATLAS'tan harita altlığını yükler                |                                                                                                                                                       
| 3    | Sistem tesisleri harita üzerinde işaretler              |                                                                                                                                                       
| 4    | Sistem renk kodlaması uygular:                          |                                                                                                                                                       
|      | - Yeşil: Geçerli belge                                  |                                                                                                                                                       
|      | - Sarı: Yenileme yaklaşıyor                             |                                                                                                                                                       
|      | - Kırmızı: Belge yok/iptal                              |                                                                                                                                                       
|      | - Mavi: Değerlendirmede                                 |                                                                                                                                                       
| 5    | Kullanıcı bir tesise tıklayarak özet bilgi görür        |                                                                                                                                                       
| 6    | Kullanıcı bölge seçerek o bölgedeki tesisleri filtreler |                                                                                                                                                       
| 7    | Kullanıcı katman seçeneklerini kullanır:                |                                                                                                                                                       
|      | - EK-1 tesisler                                         |                                                                                                                                                       
|      | - EK-2 tesisler                                         |                                                                                                                                                       
|      | - Lisans konusuna göre                                  |                                                                                                                                                       
|      | - Atık işleme tesisleri                                 |                                                                                                                                                       
| 8    | Kullanıcı ısı haritası görünümüne geçebilir             |                                                                                                                                                       
| 9    | Kullanıcı harita görünümünü rapor olarak dışa aktarır   |                                                                                                                                                       

                                                                                                                                                                                                                    
---          
## MODÜL 13: BİLDİRİM SİSTEMİ (BLD)

### UC-BLD-001: Otomatik Bildirim Gönderme                                                                                                                                                                                   
| Alan                 |                                          Değer                                         |    
|----------------------|-----------------------------------------------------------------------------------------------------------|                                                                                                       
| Use Case ID          | UC-BLD-001                                                                             |                                                                                                        
| Use Case Adı         | Sistem Tanımlı Olaylarda Otomatik Bildirim Gönderir                                    |                                                                                                        
| Aktörler             | Birincil: Sistem (otomatik)İkincil: Tüm kullanıcı tipleri                              |                                                                                                        
| Ön Koşullar          | 1. Bildirim kuralları tanımlı olmalıdır2. Kullanıcı iletişim bilgileri kayıtlı olmalıdır |                                                                                                        
| Başarılı Son Koşul   | Bildirimler ilgili kanallardan gönderilir                                              |    
| Öncelik/Kritiklik    | Kritik |                                                                                                                                                                                             
| İlgili İş Kuralları  | BR-BLD-001: e-izin bildirimleri tebliğ yerine geçer (Md.7(5)) |                                                                                                                                  
| İlgili Gereksinimler | FR-BLD-001, FR-BLD-002, FR-BLD-004 |                                                                                                    
#### Temel Akış                                                                                                                                                                                                               
| Adım |                    Açıklama                    |    
|------|----------------------------------------------------------------------------------------|                                                                                                                                                             
| 1    | Sistemde bildirim gerektiren olay gerçekleşir: |                                                                                                                                                                
|      | - Başvuru durumu değişikliği                   |                                                                                                                                                                
|      | - Ek belge/eksiklik talebi                     |                                                                                                                                                                
|      | - Karar (Uygun/Red/İade)                       |                                                                                                                                                                
|      | - Süre uyarıları                               |                                                                                                                                                                
|      | - Belge geçerlilik uyarıları                   |                                                                                                                                                                
| 2    | Sistem olaya göre bildirim şablonunu seçer     |                                                                                                                                                                
| 3    | Sistem hedef kullanıcıları belirler            |                                                                                                                                                                
| 4    | Sistem bildirim kanallarını belirler:          |                                                                                                                                                                
|      | - Sistem içi bildirim (tüm olaylar)            |                                                                                                                                                                
|      | - E-posta (önemli olaylar)                     |                                                                                                                                                                
|      | - SMS (kritik olaylar)                         |                                                                                                                                                                
| 5    | Sistem şablondaki değişkenleri doldurur        |                                                                                                                                                                
| 6    | Sistem bildirimleri gönderir                   |                                                                                                                                                                
| 7    | Sistem gönderim logunu kaydeder:               |                                                                                                                                                                
|      | - Alıcı                                        |                                                                                                                                                                
|      | - Kanal                                        |                                                                                                                                                                
|      | - Zaman                                        |                                                                                                                                                                
|      | - Başarı durumu                                |                                                                                                                                                                
#### Alternatif Akışlar                                                                                                                                                                                                       
| Kod |            Koşul            |                                 Akış                                 |    
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                                                                            
| 6a  | E-posta gönderimi başarısız | 6a1. Sistem yeniden dener (3 kez)6a2. Başarısız olursa hatayı loglar |                                                                                                             

### UC-BLD-002: Süre Uyarı Bildirimleri                                                                                                                                                                                      
|        Alan        |                           Değer                           |   
|--------------------|-------------------------------------------------------------------------------------------------------------|                                                                                                                                      
| Use Case ID        | UC-BLD-002                                                |                                                                                                                                       
| Use Case Adı       | Sistem Süre Dolmadan Kademeli Uyarı Bildirimleri Gönderir |                                                                                                                                       
| Aktörler           | Birincil: Sistem (otomatik)                               |                                                                                                                                       
| Ön Koşullar        | 1. Süreli işlem devam ediyor olmalıdır                    |                                                                                                                                       
| Başarılı Son Koşul | Kademeli uyarılar zamanında gönderilir                    |          
| Öncelik/Kritiklik | Kritik |                                                                                                                                                                                             
| İlgili Gereksinimler | FR-BLD-001, FR-DEG-045 |                                                                                                                             
#### Temel Akış                                                                                                                                                                                                               
| Adım |                          Açıklama                           |  
|------|----------------------------------------------------------------------------------------|                                                                                                                                                  
| 1    | Sistem günlük olarak süreli işlemleri tarar                 |                                                                                                                                                   
| 2    | Sistem süre bitimlerine göre uyarı zamanlarını kontrol eder |                                                                                                                                                   
| 3    | 7 gün kala:                                                 |                                                                                                                                                   
|      | 3a. "İlk uyarı" bildirimi gönderilir                        |                                                                                                                                                   
|      | 3b. Kanal: Sistem içi + E-posta                             |                                                                                                                                                   
| 4    | 3 gün kala:                                                 |                                                                                                                                                   
|      | 4a. "İkinci uyarı" bildirimi gönderilir                     |                                                                                                                                                   
|      | 4b. Kanal: Sistem içi + E-posta + SMS                       |                                                                                                                                                   
| 5    | 1 gün kala:                                                 |                                                                                                                                                   
|      | 5a. "Son uyarı" bildirimi gönderilir                        |                                                                                                                                                   
|      | 5b. Kanal: Sistem içi + E-posta + SMS                       |                                                                                                                                                   
|      | 5c. Acil durum işareti eklenir                              |                                                                                                                                                   
| 6    | Süre dolduğunda:                                            |                                                                                                                                                   
|      | 6a. "Süre doldu" bildirimi gönderilir                       |                                                                                                                                                   
|      | 6b. Otomatik işlem yapılır (red, iptal vb.)                 |                                                                                                                                                   
| 7    | Sistem tüm bildirimleri loglar                              |                                                                                                                                                   

### UC-BLD-003: Bildirim Tercihlerini Yönetme                                                                                                                                                                                
|        Alan        |                    Değer                     |    
|--------------------|-------------------------------------------------------------------------------------------------------------|                                                                                                                                                    
| Use Case ID        | UC-BLD-003                                   |                                                                                                                                                    
| Use Case Adı       | Kullanıcı Bildirim Tercihlerini Yapılandırır |                                                                                                                                                    
| Aktörler           | Birincil: Tüm Kullanıcılar                   |                                                                                                                                                    
| Ön Koşullar        | 1. Kullanıcı sisteme giriş yapmış olmalıdır  |                                                                                                                                                    
| Başarılı Son Koşul | Bildirim tercihleri kaydedilir ve uygulanır  |       
| Öncelik/Kritiklik | Orta |                                                                                                                                                                                             
| İlgili Gereksinimler | FR-BLD-005 |                                                                                                                                             
#### Temel Akış                                                                                                                                                                                                               
| Adım |                          Açıklama                           |   
|------|----------------------------------------------------------------------------------------|                                                                                                                                                 
| 1    | Kullanıcı "Hesabım > Bildirim Ayarları" menüsünü açar       |                                                                                                                                                   
| 2    | Sistem bildirim kategorilerini listeler:                    |                                                                                                                                                   
|      | - Başvuru Bildirimleri                                      |                                                                                                                                                   
|      | - Değerlendirme Bildirimleri                                |                                                                                                                                                   
|      | - Süre Uyarıları                                            |                                                                                                                                                   
|      | - Belge Bildirimleri                                        |                                                                                                                                                   
|      | - Sistem Duyuruları                                         |                                                                                                                                                   
| 3    | Her kategori için kanal seçenekleri gösterilir:             |                                                                                                                                                   
|      | - Sistem İçi: Açık/Kapalı                                   |                                                                                                                                                   
|      | - E-posta: Açık/Kapalı                                      |                                                                                                                                                   
|      | - SMS: Açık/Kapalı                                          |                                                                                                                                                   
| 4    | Kullanıcı tercihlerini işaretler                            |                                                                                                                                                   
| 5    | Kullanıcı e-posta ve telefon bilgilerini doğrular/günceller |                                                                                                                                                   
| 6    | Kullanıcı "Kaydet" butonuna tıklar                          |                                                                                                                                                   
| 7    | Sistem tercihleri kaydeder                                  |                                                                                                                                                   
| 8    | Sistem tercihler sonraki bildirimlerde uygulanır            |                                                                                                                                                   
#### Alternatif Akışlar                                                                                                                                                                                                       
| Kod |                 Koşul                 |                                                    Akış                                                     |  
|-----|----------------------------------------------|---------------------------------------------------------------------------------------|                                                             
| 4a  | Kritik bildirimler kapatılmak istenir | 4a1. Sistem uyarı gösterir: "Bu bildirimler yasal süreçlerle ilgilidir"4a2. Sistem içi bildirim kapatılamaz |                                                            

### UC-BLD-004: Bildirimleri Görüntüleme ve Yönetme                                                                                                                                                                          
|        Alan        |                           Değer                           |    
|--------------------|-------------------------------------------------------------------------------------------------------------|                                                                                                                                      
| Use Case ID        | UC-BLD-004                                                |                                                                                                                                       
| Use Case Adı       | Kullanıcı Sistem İçi Bildirimlerini Görüntüler ve Yönetir |                                                                                                                                       
| Aktörler           | Birincil: Tüm Kullanıcılar                                |                                                                                                                                       
| Ön Koşullar        | 1. Kullanıcı sisteme giriş yapmış olmalıdır               |                                                                                                                                       
| Başarılı Son Koşul | Bildirimler görüntülenir, okundu işaretlenir veya silinir |      
| Öncelik/Kritiklik | Orta |                                                                                                                                                                                             
| İlgili Gereksinimler | FR-BLD-005  |                                                                                                                                 
#### Temel Akış                                                                                                                                                                                                               
| Adım |                         Açıklama                          |  
|------|----------------------------------------------------------------------------------------|                                                                                                                                                    
| 1    | Kullanıcı sağ üst köşedeki bildirim simgesine tıklar      |                                                                                                                                                     
| 2    | Sistem son 10 bildirimi açılır listede gösterir           |                                                                                                                                                     
| 3    | Okunmamış bildirimler bold olarak gösterilir              |                                                                                                                                                     
| 4    | Kullanıcı bir bildirime tıklayarak ilgili sayfaya gider   |                                                                                                                                                     
| 5    | Bildirim otomatik olarak "okundu" işaretlenir             |                                                                                                                                                     
| 6    | Kullanıcı "Tümünü Gör" tıklayarak bildirim sayfasını açar |                                                                                                                                                     
| 7    | Bildirim sayfasında:                                      |                                                                                                                                                     
|      | - Tüm bildirimler kronolojik listelenir                   |                                                                                                                                                     
|      | - Filtreleme yapılabilir (Tarih, Tür, Okunmamış)          |                                                                                                                                                     
|      | - Toplu okundu işaretleme yapılabilir                     |                                                                                                                                                     
|      | - Silme yapılabilir                                       |                                                                                                                                                     
| 8    | Kullanıcı eski bildirimlerde arama yapabilir              |

---

## USE CASE ÖZET TABLOSU

### Modül Bazlı Use Case Listesi

#### MODÜL 1: SİSTEM YÖNETİMİ VE KONFİGÜRASYON (SYS)
|     ID     |           Use Case Adı           | Öncelik |
|------------|----------------------------------|---------|
| UC-SYS-001 | Sistem Parametrelerini Tanımlama | Kritik  |
| UC-SYS-002 | İzin/Lisans Konularını Yönetme   | Kritik  |
| UC-SYS-003 | EK-1/EK-2 Listelerini Yönetme    | Kritik  |
| UC-SYS-004 | Organizasyon Şemasını Yönetme    | Kritik  |
| UC-SYS-005 | Onay Akışlarını Yapılandırma     | Yüksek  |
| UC-SYS-006 | Belge Şablonlarını Yönetme       | Kritik  |
| UC-SYS-007 | Atık Kodlarını Yönetme           | Kritik  |
| UC-SYS-008 | Duyuru ve Menü Yapısını Yönetme  | Orta    |
#### MODÜL 2: KULLANICI VE YETKİ YÖNETİMİ (KUL)
|     ID     |                      Use Case Adı                      | Öncelik |
|------------|---------------------------------------------------------|---------|
| UC-KUL-001 | Kullanıcı Rollerini Tanımlama                          | Kritik  |
| UC-KUL-002 | Kullanıcıya Rol Atama                                  | Kritik  |
| UC-KUL-003 | Vekalet Tanımlama                                      | Orta    |
| UC-KUL-004 | Hesap Modülünden Kullanıcı Bilgilerini Senkronize Etme | Kritik  |
| UC-KUL-005 | Kullanıcı Oturumu Açma                                 | Kritik  |
| UC-KUL-006 | Rol Değişikliklerini Audit Etme                        | Orta    |
#### MODÜL 3: ÇEVRE GÖREVLİSİ İŞLEMLERİ (CG)
|    ID     |                  Use Case Adı                  | Öncelik |
|-----------|------------------------------------------------|---------|
| UC-CG-001 | Sorumlu Tesisleri Görüntüleme                  | Kritik  |
| UC-CG-002 | Tesis İçin Yapılabilecek İşlemleri Görüntüleme | Yüksek  |
| UC-CG-003 | Tesis Başvuru Durumunu e-Yeterlik'e İletme     | Kritik  |
| UC-CG-004 | Başvuru Taslağını Kaydetme                     | Yüksek  |
| UC-CG-005 | Ek Belge Talebine Yanıt Verme                  | Yüksek  |
#### MODÜL 4: BAŞVURU SÜREÇLERİ (BSV)
|     ID     |                   Use Case Adı                    | Öncelik |
|------------|---------------------------------------------------|---------|
| UC-BSV-001 | İl Müdürlüğü Uygunluk Başvurusu Oluşturma         | Kritik  |
| UC-BSV-002 | Geçici Faaliyet Belgesi (GFB) Başvurusu Oluşturma | Kritik  |
| UC-BSV-003 | Çevre İzni/Lisansı Başvurusu Oluşturma            | Kritik  |
| UC-BSV-004 | Belge Havuzundan Belge Seçme                      | Yüksek  |
| UC-BSV-005 | İş Akım Şeması ve Proses Özeti Oluşturma          | Yüksek  |
| UC-BSV-006 | Başvuruyu Çoklu Onaya Sunma                       | Yüksek  |
| UC-BSV-007 | Entegre Sistemlerden Veri Çekme                   | Kritik  |
| UC-BSV-008 | Başvuru Bedelini Ödeme                            | Kritik  |
#### MODÜL 5: DEĞERLENDİRME SÜREÇLERİ (DEG)
|     ID     |                  Use Case Adı                   | Öncelik |
|------------|-------------------------------------------------|---------|
| UC-DEG-001 | İl Müdürlüğü Uygunluk Başvurusunu Değerlendirme | Kritik  |
| UC-DEG-002 | GFB Başvurusunu Değerlendirme                   | Kritik  |
| UC-DEG-003 | Çevre İzni/Lisansı Başvurusunu Değerlendirme    | Kritik  |
| UC-DEG-004 | Eksiklik Bildirimi Yapma                        | Yüksek  |
| UC-DEG-005 | Red/İade Kararı Verme                           | Yüksek  |
| UC-DEG-006 | Değerlendirme Süresini Takip Etme               | Kritik  |
| UC-DEG-007 | Başvuruyu Personele Yönlendirme                 | Yüksek  |
| UC-DEG-008 | Belge Oluşturma ve İmzaya Gönderme              | Kritik  |
| UC-DEG-009 | Değerlendirme Geçmişini Görüntüleme             | Yüksek  |
#### MODÜL 6: YENİLEME VE GÜNCELLEME SÜREÇLERİ (YEN)
|     ID     |                     Use Case Adı                     | Öncelik |
|------------|------------------------------------------------------|---------|
| UC-YEN-001 | Belge Geçerlilik Uyarısı Alma                        | Kritik  |
| UC-YEN-002 | Süre Bitimi Nedeniyle İzin/Lisans Yenileme Başvurusu | Kritik  |
| UC-YEN-003 | Faaliyet Değişikliği Nedeniyle Belge Yenileme        | Kritik  |
| UC-YEN-004 | Unvan Değişikliği Başvurusu                          | Yüksek  |
| UC-YEN-005 | Atık Kodu Ekleme Talebi                              | Yüksek  |
| UC-YEN-006 | Lisans Konusu Çıkarma Talebi                         | Yüksek  |
| UC-YEN-007 | Yeni İzin/Lisans Konusu Ekleme                       | Yüksek  |
| UC-YEN-008 | İyileştirme Değişikliği Bildirimi                    | Yüksek  |
#### MODÜL 7: MUAFİYET İŞLEMLERİ (MUA)
|     ID     |               Use Case Adı               | Öncelik |
|------------|------------------------------------------|---------|
| UC-MUA-001 | Çevre İzni Muafiyet Başvurusu            | Orta    |
| UC-MUA-002 | Çevresel Gürültü Muafiyeti Değerlendirme | Orta    |
| UC-MUA-003 | Geçici İşletme Bildirimi                 | Orta    |
| UC-MUA-004 | Muafiyet Durumunu Sorgulama              | Orta    |
#### MODÜL 8: İPTAL SÜREÇLERİ (IPT)
|     ID     |                Use Case Adı                 | Öncelik |
|------------|---------------------------------------------|---------|
| UC-IPT-001 | GFB Otomatik İptal (Süre Aşımı)             | Kritik  |
| UC-IPT-002 | GFB İptal (Aykırılık Tespiti)               | Kritik  |
| UC-IPT-003 | İzin/Lisans İptal (Uygunsuzluk Giderilmedi) | Kritik  |
| UC-IPT-004 | Manuel Belge İptal Etme                     | Kritik  |
| UC-IPT-005 | İptal Edilen Belgeyi Yeniden Aktifleştirme  | Orta    |
| UC-IPT-006 | Faaliyet Sonlandırma Bildirimi              | Yüksek  |
| UC-IPT-007 | Cezalı Yeniden Başvuru Yönetimi             | Kritik  |
#### MODÜL 9: GÖRÜŞ VE ÖZEL İŞLEMLER (OZL)
|     ID     |                Use Case Adı                          | Öncelik |
|------------|------------------------------------------------------|---------|
| UC-OZL-001 | Görüş Talebi Oluşturma                               | Orta    |
| UC-OZL-002 | Görüş Talebini Değerlendirme ve Yanıtlama            | Orta    |
| UC-OZL-003 | ÖFB Kayıt İşlemi Yapma                               | Orta    |
| UC-OZL-004 | ÖFB Şablon ve Versiyon Yönetimi                      | Orta    |
| UC-OZL-005 | Belge Askıya Alma ve Askı Kaldırma                   | Yüksek  |
#### MODÜL 10: BELGE YÖNETİMİ (BLG)
|     ID     |              Use Case Adı              | Öncelik |
|------------|----------------------------------------|---------|
| UC-BLG-001 | Belge Oluşturma ve ÇKN Atama           | Kritik  |
| UC-BLG-002 | Belge Versiyonlama                     | Kritik  |
| UC-BLG-003 | Belge Geçmişini Görüntüleme            | Yüksek  |
| UC-BLG-004 | Belge Doğrulama (Kamuya Açık)          | Yüksek  |
| UC-BLG-005 | Belge Arşivleme ve Uzun Vadeli Saklama | Kritik  |
#### MODÜL 11: RAPORLAMA VE ANALİTİK (RPR)
|     ID     |              Use Case Adı              | Öncelik |
|------------|----------------------------------------|---------|
| UC-RPR-001 | Yönetici Dashboard Görüntüleme         | Yüksek  |
| UC-RPR-002 | Harita Üzerinden CBS Tabanlı Raporlama | Yüksek  |
| UC-RPR-003 | Dinamik Rapor Oluşturma                | Yüksek  |
| UC-RPR-004 | Rapor Dışa Aktarma ve Paylaşma         | Yüksek  |
| UC-RPR-005 | Kamuya Açık Raporlama Sayfası          | Orta    |
| UC-RPR-006 | Süreç İzleme ve Uyumsuzluk Raporu      | Yüksek  |
#### MODÜL 12: ENTEGRASYON YÖNETİMİ (ENT)
|     ID     |                   Use Case Adı                   | Öncelik |
|------------|--------------------------------------------------|---------|
| UC-ENT-001 | e-ÇED Sisteminden Veri Çekme                     | Kritik  |
| UC-ENT-002 | Belgenet ile İmza Entegrasyonu                   | Kritik  |
| UC-ENT-003 | Entegrasyon Sağlık Durumunu İzleme               | Yüksek  |
| UC-ENT-004 | Ödeme Entegrasyonu ve Doğrulama                  | Kritik  |
| UC-ENT-005 | Bakanlık İç Sistemleri ile Veri Paylaşımı        | Yüksek  |
| UC-ENT-006 | Dış Kurum Veri Sorgulama                         | Yüksek  |
#### MODÜL 13: BİLDİRİM SİSTEMİ (BLD)
|     ID     |            Use Case Adı             | Öncelik |
|------------|-------------------------------------|---------|
| UC-BLD-001 | Otomatik Bildirim Gönderme          | Yüksek  |
| UC-BLD-002 | Süre Uyarı Bildirimleri             | Yüksek  |
| UC-BLD-003 | Bildirim Tercihlerini Yönetme       | Orta    |
| UC-BLD-004 | Bildirimleri Görüntüleme ve Yönetme | Orta    |

### İSTATİSTİK ÖZETİ
|          Metrik           | Değer |
|---------------------------|-------|
| Toplam Use Case Sayısı    | 81    |
| Kritik Öncelikli          | 35    |
| Yüksek Öncelikli          | 30    |
| Orta Öncelikli            | 16    |
| Aktör Sayısı (Birincil)   | 10    |
| Aktör Sayısı (Dış Sistem) | 8     |
| Modül Sayısı              | 13    |