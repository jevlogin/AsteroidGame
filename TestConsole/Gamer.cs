using System;

namespace TestConsole
{
    class Gamer
    {
        private string _Name;
        private DateTime _DayOfBirth;


        //  Это свойство.
        public string Name
        {
            get
            {
                //return _Name ?? string.Empty                  //  А это не тернарный оператор )))
                //return _Name == null ? string.Empty : _Name;  //  Тернарный оператор
                
                //  А это через стандартный if else
                if (_Name == null)
                {
                    return string.Empty;
                }
                else
                {
                    return _Name;
                }
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                _Name = value;
            }
        }

        public Gamer(string Name, DateTime DayOfBirth)
        {
            _Name = Name;
            _DayOfBirth = DayOfBirth;

        }

        //public void SetName(string value)
        //{
        //    _Name = value;
        //}
        //public string GetName()
        //{
        //    return _Name;
        //}


        internal int GetNameLength()
        {
            return Name.Length;
        }

        public void SayYourName()
        {
            Console.WriteLine($"{_Name} {_DayOfBirth:dd:MM:yyyy HH:mm:ss}");
        }
    }
}
