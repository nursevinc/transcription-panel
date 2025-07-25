# Transcription Panel 


##  Kullanılan Teknolojiler

- Backend: ASP.NET Core Web API
- Frontend: Angular
- Veritabanı: MSSQL
- JWT Authentication
- Bootstrap / Angular Material

##  Kurulum ve Çalıştırma

### Backend (.NET Core API)

1. Visual Studio veya terminal üzerinden `TranscriptionAPI` projesini aç.
2. `appsettings.json` içine doğru `ConnectionString` bilgilerini gir.
3. Terminalde:
   ```bash
   dotnet ef database update
   dotnet run
   API Swagger arayüzü https://localhost:7069/swagger adresinden erişilebilir.

   
  Frontend (Angular)
  
1-cd transcription-panel

2-Gerekli paketleri yükle:

npm install

3-Uygulamayı başlat:

ng serve

4- http://localhost:4200 adresinden giriş yapabilirsin.


Test Kullanıcıları:

username: admin
password:1234

http://localhost:4200/audios >>> buradan ses kayıtları görüntülenebilir, transkripsiyon kaydedilebilir ya da değiştirilebilir.
http://localhost:4200/logs  >>> log kayıtları görüntülenebilir. kullanıcı, yaptığı işlem ve tarih şeklinde.
http://localhost:4200/user-management >>>> mevcut kullanıcılar görüntülenebilir. admin ya da editör rolünde yeni kullanıcılar eklenebilir.
