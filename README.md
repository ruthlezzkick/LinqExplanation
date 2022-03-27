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
  Proste. Większość początkujących developerów da sobie radę z tak postawionym problemem. Spora część z nich, wykona to jednak bezrefleksyjnie, nie dokońca rozumiejąc w pełni zastosowaną składnię.  Jak to się dzieje że używamy jakiejś metody ‘Where’ na naszej liście faktur? Przecież nigdzie nie deklarowaliśmy jej na żadnej klasie. Co to za dziwna konstrukcja z tymi ‘x’ i jakimiś dziwnymi strzałkami ? Wiem, że tak to się robi, ale dlaczego, co tu się właściwie wydarzyło ?

  Zapomnijmy na moment, że mamy do dyspozycji LINQ. Spróbujmy napisać nasze własne uproszczone implementacje tej biblioteki, przechodząc krok po kroku przez różne bariery. Tłumaczenie może być mocno łopatologiczne  ale taki nietypowy sposób wybrałem na wyjaśnienie tematu.
  
