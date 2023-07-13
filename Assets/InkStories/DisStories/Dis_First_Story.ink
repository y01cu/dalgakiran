EXTERNAL FlowTheGame()
EXTERNAL DestroyCanvas()
EXTERNAL PlayHuhSound()
EXTERNAL ActivateNextApp()
EXTERNAL MakeCanvasDissappear()
EXTERNAL IncrementSocialMediaApp()
EXTERNAL IncrementTextEditingApp()

- Merhaba! Ben Çağla. Ortak arkadaşımız senin bugün burada olacağını söyledi.
 * [Merhaba]
 * [Selam]
-Direkt konuya girelim. Bu şehir çılgına dönüyor!
    *[Dur biraz Çağla, sakin ol]
    *[...]
    -- Sadece biraz gerginim. Eminim duymuşsundur, şehir bir Gökteki Şato inşa ediyor.
        **[Gökteki Şato ne ki?]
        --- Tam olarak düşündüğün şey. Bir gözlemevi. Uzayı izleyebileceğimiz ve bilim adına yeni şeyler keşfedebileceğimiz bir yer.
            ***[Kulağa zararsız geliyor]
            ----Sadece çocukların uzaya merakını tatmin etmek için vergi mükelleflerinin parasını harcamamız gerekiyor mu?
                ****[Mantıklı]
                -----Bunu durdurmamız gerekiyor
                *****[Nasıl yardımcı olabilirim?]
        **[Yok artık!]
        ---Aynen öyle! Sesimizi duyumamız gerekiyor!
        ***[Nasıl yardımcı olabilirim?]


-Şato'ya karşı olan küçük, aklı başında olan bir grubunun parçasıyım, daha çok desteğe ihtiyacımız var!
*[Evet]
*["Aklı başında"]

-İnsanların dikkatini çekmek için gerçekten yardıma ihtiyacımız var. Bana yardım edecek misin?
*[Tabi, neden olmasın]

-Nereden başlamalıyız?
    *[Yıldızlardan bir pankart yap]
    //HUH?! sound effect here
    ~PlayHuhSound()
    -- NEDEN?!? Bu hem zaman alıcı hem de gerçekçi değil! Başka bir şey deneyelim.
        **[Sosyal medyada mesaj yay]
        ---Çok daha iyi. İnsanların söylediklerimize yapışmasına ihtiyacımız var. Tabletindeki uygulamayı kontrol et, böylece bir gönderi yapabiliriz!
            ***[Tamam]
            ~ActivateNextApp()
            ~MakeCanvasDissappear()
            ~IncrementTextEditingApp()
    
    *[Sosyal medyada bir gönderi yap]
    --Akıllıca. İnsanların bizim sesimizi duyması gerekiyor. Tabletini çıkart bir gönderi paylaşalım.
    //insert function here 
     ~IncrementTextEditingApp()
    
-Bu işte doğuştan yeteneklisin. İnsanlar senin gönderini farketmeye başladılar bile.
    *[Meşhur oldum.]
    ~IncrementSocialMediaApp()
    --Aynen öyle! Sosyal medyaya gir de bir bak!
    ~MakeCanvasDissappear()
    //insert function here
    
    // social media app needs to be opened here with
-İyi iş çıkardın. İnsanlar şato hakkında konuşuyorlar. Hadi bu işi biraz daha zorlayıp bir gönderi daha paylaşalım
    *[Evet!]
    //İnsert function here
    ~IncrementTextEditingApp()
    ~MakeCanvasDissappear()
    
    // ~SendNewTextPost()
-Sosyal medyaya bak!
    //insert function here
    ~IncrementSocialMediaApp()
-Sende parlak bir gelecek görüyorum.
    *[Annem benimle gurur duyardı.]
// -Hemde nasıl. Devam edelim. Diğerleriyle tanışma vakti.
    //insert function here

~FlowTheGame()
~DestroyCanvas()

