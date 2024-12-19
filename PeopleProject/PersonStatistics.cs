namespace PeopleProject
{
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
