# GameStore.Api

ASP.NET Core **Minimal API** ile yazılmış basit bir oyun mağazası REST API'si. [.NET Crash Course](https://www.youtube.com/watch?v=YbRe4iIVYJk) videosu takip edilerek öğrenme amaçlı geliştirildi.

Veriler şimdilik bellekte (in-memory `List<GameDto>`) tutulur; uygulama yeniden başlatıldığında başlangıç verilerine döner.

## Teknolojiler

- .NET 10 / ASP.NET Core Minimal API
- Route grupları (`MapGroup`)
- DTO'lar için C# `record` tipleri
- `System.ComponentModel.DataAnnotations` + `AddValidation()` ile otomatik istek doğrulama

## Proje Yapısı

```
GameStore/
├── GameStore.slnx
└── GameStore.Api/
    ├── Program.cs                 # Uygulama girişi, servis kayıtları
    ├── Endpoints/
    │   └── GamesEndpoints.cs      # /games endpoint'leri
    ├── Dtos/
    │   ├── GameDto.cs             # Dönüş modeli
    │   ├── CreateGameDto.cs       # POST istek modeli
    │   └── UpdateGameDto.cs       # PUT istek modeli
    ├── Properties/
    │   └── launchSettings.json
    └── games.http                 # Endpoint'leri denemek için HTTP istekleri
```

## Kurulum ve Çalıştırma

Gereksinim: [.NET 10 SDK](https://dotnet.microsoft.com/download)

```bash
git clone <repo-url>
cd GameStore/GameStore.Api
dotnet run
```

API varsayılan olarak şu adreste çalışır: `http://localhost:5007`

HTTPS profiliyle çalıştırmak için:

```bash
dotnet run --launch-profile https   # https://localhost:7237
```

## Endpoint'ler

| Metot  | Yol           | Açıklama                 | Başarılı yanıt     |
|--------|---------------|--------------------------|--------------------|
| GET    | `/games`      | Tüm oyunları listeler    | `200 OK`           |
| GET    | `/games/{id}` | Tek oyunu getirir        | `200 OK` / `404`   |
| POST   | `/games`      | Yeni oyun ekler          | `201 Created`      |
| PUT    | `/games/{id}` | Mevcut oyunu günceller   | `204 No Content` / `404` |
| DELETE | `/games/{id}` | Oyunu siler              | `204 No Content`   |

### Örnek istek

```http
POST http://localhost:5007/games
Content-Type: application/json

{
    "name": "Super Mario Bros. Wonder",
    "genre": "Platformer",
    "price": 59.99,
    "releaseDay": "2023-10-20"
}
```

Tüm örnek istekler [GameStore.Api/games.http](GameStore.Api/games.http) dosyasında. VS Code'da [REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) eklentisiyle doğrudan çalıştırılabilir.

## Doğrulama Kuralları

`CreateGameDto` ve `UpdateGameDto` için:

| Alan    | Kural                         |
|---------|-------------------------------|
| `name`  | Zorunlu, en fazla 50 karakter |
| `genre` | Zorunlu, en fazla 20 karakter |
| `price` | 1 ile 100 arasında            |

Kurala uymayan isteklere `400 Bad Request` ve hata detayları döner.

## Kaynak

- Video: [.NET Crash Course](https://www.youtube.com/watch?v=YbRe4iIVYJk)
