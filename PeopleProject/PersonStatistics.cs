namespace PeopleProject
{
    /*
     A PersonStatistics osztály függvényeit C# nyelv esetén nagy betűvel kezdje. Az osztály
megvalósítása során az alábbiakra ügyeljen.
a.) Az osztály tárolja az emberek adatait egy people nevű lista adattagban. A lista adattag
konstruktor paraméterében, valamint setter segítségével is legyen megadható. Csak egy
konstruktorral rendelkezzen az osztály, amelyben a lista adattag megadása kötelező. A
lista lehet üres is, viszont null értéket nem vehet fel. A további függvények ebben a
listában található adatokkal dolgozzanak. Megvalósítási javaslat:
• C# nyelv esetén People nevű property, melynek settere publikus, gettere privát.
Külön adattag létrehozása nem kötelező, használhatóak a C# nyelvi elemei.
• Java nyelv esetén people privát adattag létrehozása és hozzá publikus setPeople
függvény létrehozása (lombok használható)
• JavaScript / TypeScript esetén people privát adattag létrehozása és hozzá publikus
set property létrehozása.
b.) getAverageAge() – adja vissza az összes személy átlagéletkorát
c.) getNumberOfStudents() – Adja vissza a tanulók számát.
d.) getPersonWithHighestScore() – Adja a legtöbb ponttal rendelkező személyt
e.) getAverageScoreOfStudents() – Adja vissza a tanulók átlag pontszámát
f.) getOldestStudent()– Adja vissza a legidősebb tanulót
g.) isAnyoneFailing()– Adja vissza hogy van-e olyan személy, aki megbukott a teszten
(kevesebb mint 40 pontot ért el)
     */

    public class PersonStatistics
    {
        private List<Person> people;
        public List<Person> People
        {
            private get => people;
            set
            {
                if (value == null) throw new ArgumentNullException("A lista nem lehet null", nameof(value));
                people = value;
            } 
        }

        public PersonStatistics(List<Person> people)
        {
            if(people == null) throw new ArgumentNullException("A lista nem lehet null", nameof(people));
            this.people = people;
        }

        public double GetAverageAge() => People.Any() ? People.Average(p => p.Age) : 0;

        public int GetNumberOfStudents() => People.Count(p => p.IsStudent);

        public Person? GetPersonWithHighestScore() => People.Count == 0 ?  null : People.OrderByDescending(p => p.Score).FirstOrDefault();
           
           

        public double GetAverageScoreOfStudents() =>
            People.Where(p => p.IsStudent).DefaultIfEmpty().Average(p => p?.Score ?? 0);

        public Person? GetOldestStudent() => People.Count == 0 ? null : People.Where(p => p.IsStudent).OrderByDescending(p => p.Age).FirstOrDefault();
        
        public bool IsAnyoneFailing() => People.Any(p => p.Score < 40);
    }



    }
