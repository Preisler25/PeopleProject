using PeopleProject;

namespace TestPeopleProject
{
    public class Tests
    {
        

        [SetUp]
        public void SetUp()
        {
            
        }

        //PersonStatistics
        [Test]
        public void PersonStatistics_RendesListaval_NemDob()
        {
            PersonStatistics _personStatistics;

            var people = new List<Person>
            {
            new Person("Alice", 20, true, 85),
            new Person("Bob", 22, true, 55),
            };

            Assert.DoesNotThrow(() => new PersonStatistics(people) );
        }

        [Test]
        public void PersonStatistics_Null_NullEx_Dob()
        {
            Assert.Throws<ArgumentNullException>(() => new PersonStatistics(null));
        }


        // GetAverageAge 

        [Test]
        public void GetAverageAge_ListavalAmiEgeszesAtlaggal_HelyesErteketAdd()
        {
            PersonStatistics _personStatistics;

            var people = new List<Person>
            {
            new Person("Alice", 20, true, 85),
            new Person("Bob", 22, true, 55),
            };
            _personStatistics = new PersonStatistics(people);

            Assert.AreEqual(21, _personStatistics.GetAverageAge());
        }

        [Test]
        public void GetAverageAge_ListavalAmiTortAtlaggal_HelyesErteketAdd()
        {
            PersonStatistics _personStatistics;

            var people = new List<Person>
            {
            new Person("Alice", 20, true, 85),
            new Person("Bob", 21, true, 55),
            };
            _personStatistics = new PersonStatistics(people);

            Assert.AreEqual(20.5, _personStatistics.GetAverageAge());
        }

        [Test]
        public void GetAverageAge_UresListaval_NullatAddVissza()
        {
            PersonStatistics _personStatistics;

            var people = new List<Person>{};
            _personStatistics = new PersonStatistics(people);

            Assert.AreEqual(0, _personStatistics.GetAverageAge());
        }

        // GetNumberOfStudents

        [Test]
        public void GetNumberOfStudents_ListavalCsakDiakokkal_HelyesEredmenytAddVissza()
        {
            PersonStatistics _personStatistics = new PersonStatistics(new List<Person>{ 
                new Person("Alice", 20, true, 85),
                new Person("Bob", 21, true, 55),
            });
            Assert.AreEqual(2, _personStatistics.GetNumberOfStudents());
        }

        [Test]
        public void GetNumberOfStudents_ListavalCsakTanarokkal_HelyesEredmenytAddVissza()
        {
            PersonStatistics _personStatistics = new PersonStatistics(new List<Person>{
                new Person("Alice", 20, false, 85),
                new Person("Bob", 21, false, 55),
            });
            Assert.AreEqual(0, _personStatistics.GetNumberOfStudents());
        }

        [Test]
        public void GetNumberOfStudents_ListavalMixTanarDiak_HelyesEredmenytAddVissza()
        {
            PersonStatistics _personStatistics = new PersonStatistics(new List<Person>{
                new Person("Alice", 20, false, 85),
                new Person("Bob", 21, true, 55),
            });
            Assert.AreEqual(1, _personStatistics.GetNumberOfStudents());
        }

        [Test]
        public void GetNumberOfStudents_UresListaval_NullatAddVissza()
        {
            PersonStatistics _personStatistics = new PersonStatistics(new List<Person> { });
            Assert.AreEqual(0, _personStatistics.GetNumberOfStudents());
        }


        //GetPersonWithHighestScore

        [Test]
        public void GetPersonWithHighestScore_UresListaval_NulltAddVissza()
        {
            PersonStatistics _personStatistics = new PersonStatistics(new List<Person> { });
            var person = _personStatistics.GetPersonWithHighestScore();
            Assert.AreEqual(null, person);
        }


        [Test]
        public void GetPersonWithHighestScore_EgyenloListaban_VisszaAddKisebbIndexel()
        {
            PersonStatistics _personStatistics = new PersonStatistics(new List<Person> {
                new Person("Alice", 20, true, 85),
                new Person("Bob", 21, true, 85),
            });
            var person = _personStatistics.GetPersonWithHighestScore();
            Assert.AreEqual("Alice", person.Name);
            Assert.AreNotEqual("Bob", person.Name);
        }


        [Test]
        public void GetPersonWithHighestScore_HelyesListaban_VisszaAdd()
        {
            PersonStatistics _personStatistics = new PersonStatistics(new List<Person> {
                new Person("Alice", 20, true, 85),
                new Person("Bob", 21, true, 86),
            });
            var person = _personStatistics.GetPersonWithHighestScore();
            Assert.AreNotEqual("Alice", person.Name);
        }



        //GetAverageScoreOfStudents

        [Test]
        public void GetAverageScoreOfStudents_HelyesListaval_EgeszAtlaggal_HelyesenAddVissza()
        {
            PersonStatistics _personStatistics = new PersonStatistics(new List<Person> {
                new Person("Alice", 20, true, 85),
                new Person("Bob", 21, true, 87),
            }); 
            Assert.AreEqual(86, _personStatistics.GetAverageScoreOfStudents(), 0.01);
        }

        [Test]
        public void GetAverageScoreOfStudents_HelyesListaval_TortAtlaggal_HelyesenAddVissza()
        {
            PersonStatistics _personStatistics = new PersonStatistics(new List<Person> {
                new Person("Alice", 20, true, 85),
                new Person("Bob", 21, true, 86),
            });
            Assert.AreEqual(85.5, _personStatistics.GetAverageScoreOfStudents(), 0.01);
        }

        [Test]
        public void GetAverageScoreOfStudents_UresListaval_NullatAddVissza()
        {
            PersonStatistics _personStatistics = new PersonStatistics(new List<Person> {});
            Assert.AreEqual(0, _personStatistics.GetAverageScoreOfStudents());
        }

        //GetOldestStudent

        [Test]
        public void GetOldestStudent_HelyesListaval_EgysegesKorNelkul_VisszaAdd()
        {
            PersonStatistics _personStatistics = new PersonStatistics(new List<Person> {
                new Person("Alice", 20, true, 85),
                new Person("Bob", 21, true, 86),
            });
            var person = _personStatistics.GetOldestStudent();
            Assert.AreEqual("Bob", person.Name);
        }

        [Test]
        public void GetOldestStudent_HelyesListaval_DeEgységesKornal_KisebbIndexutAdjaVissza()
        {
            PersonStatistics _personStatistics = new PersonStatistics(new List<Person> {
                new Person("Alice", 21, true, 85),
                new Person("Bob", 21, true, 86),
            });
            var person = _personStatistics.GetOldestStudent();
            Assert.AreEqual("Alice", person.Name);
        }

        [Test]
        public void GetOldestStudent_UresListaval_NulltAddVissza()
        {
            PersonStatistics _personStatistics = new PersonStatistics(new List<Person> {});
            var person = _personStatistics.GetOldestStudent();
            Assert.AreEqual(null, person);
        }

        //IsAnyoneFailing

        [Test]
        public void IsAnyoneFailing_UesListaval_SenkiNemBukik_FalsetAddVissza()
        {
            PersonStatistics _personStatistics = new PersonStatistics(new List<Person> { });
            Assert.IsFalse(_personStatistics.IsAnyoneFailing());
        }

        [Test]
        public void IsAnyoneFailing_HelyesListaval_EgyemberBukik_TruetAddVissza()
        {
            PersonStatistics _personStatistics = new PersonStatistics(new List<Person> { 
                new Person("Alice", 20, true, 39),
                new Person("Bob", 21, true, 85),
            });
            Assert.IsTrue(_personStatistics.IsAnyoneFailing());
        }

        [Test]
        public void IsAnyoneFailing_HelyesListaval_KetEmberBukik_TruetAddVissza()
        {
            PersonStatistics _personStatistics = new PersonStatistics(new List<Person> {
                new Person("Alice", 20, true, 39),
                new Person("Bob", 21, true, 35),
            });
            Assert.IsTrue(_personStatistics.IsAnyoneFailing());
        }
    }
}