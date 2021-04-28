namespace Lesson09
{
    public class Absovent : Student
    {
        public Absovent(string jmeno, string primeni, int rokUkonceni) : base(jmeno, primeni)
        {
            RokUkonceni = rokUkonceni;
        }

        public int RokUkonceni { get; set; }
    }
}
