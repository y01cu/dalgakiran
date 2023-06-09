EXTERNAL ActivateTempButton(soundName)
EXTERNAL PlayHuhSound()

- Dışarıda hava çok hojdır.
* [Dışarıya çık.]
~ PlayHuhSound()

* [Evde kal.]
    -- Evde kalıyorsun, bitkin soluk görünüyor.
    ** [Kalmağa devam et.]
        --- Evde kalıyorsun, bitkin soluk görünüyor.
        ~ ActivateTempButton("whack")
        *** [Dışarıya çık lütfen.]      
          
    ** [Dışarıya çık.]              



- Dışarıya çıktın. Aaa o da ne...

-----------> END