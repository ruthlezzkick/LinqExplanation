# Wstęp
Wchodząc w świat języka C# i frameworka .Net świeży programista dość szybko styka się z technologią Linq. Nawet jeśli zapozna się wcześniej z dokumentacją i dokładnie przejdzie przez większość konceptów i mechanizmów programowania w tej technologii, to stosując Linq, nie zawsze do końca rozumie jak ono jest zbudowane i jak działa. Zazwyczaj wcale nie przeszkadza to w sprawnym operowaniu na kolekcjach. Mówiąc prościej i bardziej obrazowo.

```csharp
/* Świeżak , masz tu listę faktur */
List<Invoice> invoices;
invoices = GetAllInvoices();
/* Zwróć mi proszę z tej listy tylko te faktury, których wartość jest większa niż 2000 */
```

 ```csharp 
var filteredInvoices = invoices.Where(x=>x.InvoiceValue >2000);
/* Proszęęęęę */
```
  Proste. Większość początkujących developerów da sobie radę z tak postawionym problemem. Spora część z nich, wykona to jednak bezrefleksyjnie, nie dokońca rozumiejąc w pełni zastosowaną składnię.  Jak to się dzieje, że używamy jakiejś metody ‘Where’ na naszej liście faktur? Przecież nigdzie nie deklarowaliśmy jej na żadnej klasie. Co to za dziwna konstrukcja z tymi ‘x’ i jakimiś dziwnymi strzałkami ? Wiem, że tak to się robi, ale dlaczego, co tu się właściwie wydarzyło ?
  
  Przez to że LINQ jest tak powszechne i każdy programista .NET styka się z nim już na samym początku swojej drogi, jest to dobry element do wyjaśnienia pewnych konceptów, które podczas poznawania C# mogły zostać potraktowane trochę po macoszemu. Będą więc tutaj rozkminiane:
 -	Delegaty
 -	Delegaty generyczne
 -	Wyrażenia lambda
 - Metody rozszerzające

 Przy okazji możemy też wspomnień coś więcej ogólnie o klasach generycznych na przykładzie generycznych kolekcji i nieco rozjaśnić idee magicznego interfejsu IEnumerable.

  Zapomnijmy na moment, że mamy do dyspozycji LINQ. Spróbujmy napisać nasze własne uproszczone implementacje tej biblioteki, przechodząc krok po kroku przez różne bariery. Tłumaczenie może być mocno łopatologiczne  ale taki nietypowy sposób wybrałem na wyjaśnienie tematu.
  
  ### Projekt
  Podczas omawiania problemu, przykładowy projekt i klasy wchodzące w jego skład warto budować stopniowo, krok po kroku wszystko wyjaśniając.
  Finalny Projekt będzie wyglądał tak:
  
  ![Solucja](IMG/Solution.PNG)
  
  Co zawierają poszczególne foldery i klasy?
  
  - Folder Domain - zawiera przykładowe klasy naszych kolekcji
  - Klasa DomainFactory - to kreator przykładowych kolekcji tych klas
  - Klasa Helper - to klasa, w której umieściliśmy kilka pomocniczych metod. Głównie do wyswietlania wyników w konsoli, ale też przykładowe metody zwracające wartość bool dla parametru Invoice
  - Klasa Program - tutaj odbywają się wszelkie testy budowanych mechanizmów
  - Folder AltLinq - tutaj stopniowo budujemy alternatywne wersje dla naszego LINQ
  
  ### Main
  W metodzie Main naszego programu tworzymy przykładowe kolekcje
  ```csharp 
  var invoices = DomainFactory.FakeInvoiceList();
  var drivers = DomainFactory.FakeDriverList();
  ```
  ### Krok 0
  Na rozgrzewkę wykonajmy na nich kilka filtrowań za pomocą metody Where z oryginalnego LINQ
  ```csharp 
  var linqWarsawInvoices = invoices.Where(x=>x.City=="Warszawa");
  var linqAprilInvoices = invoices.Where(x => x.CrtDate.Month==4);
  var linqInvoicesWithValueMoreThan30 = invoices.Where(x => x.Value>30);
  var linqAuchanInvoices = invoices.Where(x => x.Customer=="Auchan");
  var linqInvoicesWithBeer = invoices.Where(x => x.InvoiceItems.Any(y => y.ItemName == "Beer"));
  ```
  Nie będziemy wyświetlać wyników w konsoli, ale zapewniam, że wynikowe kolekcje zawierają wyniki zgodne z intencją.
  ### Krok 1
  Cofnijmy się nieco w czasie do roku 2007. Nie został jeszcze wydany VS 2008 z C# 3.0 i .Net Framework 3.5. Nie  dysponujemy jeszcze technologią LINQ.  Spróbujmy zwrócić listę faktur na Warszawę.
  Bez zbędnych wyjaśnień, najprościej zrobimy to tak:
  ```csharp 
  var warsawInvoices = new List<Invoice>();
   foreach (var invoice in invoices)
   {
       if (invoice.City == "Warszawa")
       {
           warsawInvoices.Add(invoice);
       }
   }
   ```
  I jeszcze trochę bardziej złożony przykład. Zwróćmy te faktury, które w swoich pozycjach zawierają piwo.
  ```csharp 
  var invoicesWithBeer = new List<Invoice>();
  foreach (var invoice in invoices)
  {
      foreach (var invoiceItem in invoice.InvoiceItems)
      {
          if (invoiceItem.ItemName == "Beer")
          {
              invoicesWithBeer.Add(invoice);
              break;
          }
      }
  }
  ```
  Na wszelki wypadek szybkie wyjaśnienie co tu się zadziało. Iterujemy po każdej fakturze w kolekcji. Dla każdej faktury iterujemy po każdej pozycji. Sprawdzamy czy nazwa pozycji to piwo. Jeśli tak to przerywamy tą niższą iterację i przechodzimy do sprawdzania kolejnej faktury. Oczywiście Piwo na pozycji powoduje dodanie faktury do nowej wynikowej kolekcji.
  ### Krok 2
  Stwórzmy statyczną klasę ConstLinq z dwiema metodami, które zrobią dokładnie to co nasze iteracje wyżej. Czyli tak naprawdę opakujmy ten kod w osobne metody.
  ```csharp
  public static class ConstLinq
    {
        public static IEnumerable<Invoice> WhereInvoiceCityIsEqualWarsaw(IEnumerable<Invoice> invoices)
        {
            var resultList = new List<Invoice>();
            foreach (var invoice in invoices)
            {
                if (invoice.City == "Warszawa")
                {
                    resultList.Add(invoice);
                }
            }
            return resultList;
        }

        public static IEnumerable<Invoice> WhereInvoiceHasBeer(IEnumerable<Invoice> invoices)
        {
            var resultList = new List<Invoice>();
            foreach (var invoice in invoices)
            {
                foreach (var invoiceItem in invoice.InvoiceItems)
                {
                    if (invoiceItem.ItemName == "Beer")
                    {
                        resultList.Add(invoice);
                        break;
                    }
                }
            }
            return resultList;
        }
    }
  ```
  
    
    Wywołanie tych metod na naszej pierwszej pseudo klasie LINQ będzie wyglądało tak:
    Metody przyjmują w parametrze pełne kolekcje a zwracają już pofiltrowane
```csharp

    var clInvoicesWithBeer = ConstLinq.WhereInvoiceHasBeer(invoices);
    var clWarsawInvoices = ConstLinq.WhereInvoiceCityIsEqualWarsaw(invoices);
```

    
    
  
  
