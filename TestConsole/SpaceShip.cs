using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class SpaceShip
    {
        //  Класс это полнофункциаональный тип данных. Хранится в куче. Ссылочный.
        private Vector2D _Position = new Vector2D(5, 7);

        //  Отличный комментарий: "Давайте сделаем Вектор 2Д"
        public Vector2D Position { get => _Position; set => _Position = value; }


        //  Конструктор по умолчанию
        public SpaceShip()
        {

        }
        //  Конструктор параметрический
        public SpaceShip(Vector2D Position)
        {
            _Position = Position;
        }
    }
}
