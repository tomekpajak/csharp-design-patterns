# Design patterns using c#
This is my sandbox for design patterns in c#

- Adapter

## Design patterns
### Adapter
Umożliwia wykorzystanie klasy A implementującej interfejs A przez klienta, który oczekuje interfejsu B.\
W tym celu tworzy się klasę AdapterA implementującą imterfejs B, gdzie poszczególne metody interfejsu B są delegowane do metod interfejsu A.

Jednym z zastosowań wzorca adapter jest zamiana zależności zewnętrznych na zależności wewnętrzne.\
Np. w usłudze mamy zależność od zewnętrznej biblioteki logującej. 
Jeśli utworzymy wewnętrzny interfejs ILogger oraz stworzymy adapter zewnętrznej biblioteki implementujący interfejs ILogger zmienimy zewnętrzną zależność na zależność wewnętrzną.