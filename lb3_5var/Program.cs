using System.Collections.Generic;

namespace lb3_5var;
class Program
{
    //виды топлива
    public enum Gas { A92, A100 }

    //класс работник
    public class Worker
    {

        public string _Name { get; set; }
        public Gas _Gas;
        //конструктор для работника(имя и тип топлива который заливает)
        public Worker(string name, Gas gas)
        {
            _Name = name;
            _Gas = gas;
        }

        //вывод информации о работнике
        public void PrintWorker()
        {
            Console.WriteLine("Имя работника: " + _Name + '\n' + "С каким топливом работает: " + _Gas);
        }
    }

    //класс для машин
    public class Car
    {
        public string _Name;
        public Gas _Gas;
        public int _maxOil;
        public int _nowOil;
        //конструктор(имя модели, тип, максимальный размер, сколько на данный момент бензина)
        public Car(string name, Gas gas, int max, int now)
        {
            _Name = name;
            _Gas = gas;
            _maxOil = max;
            _nowOil = now;
        }

        //вывод информации о машине 
        public void printCar()
        {
            Console.WriteLine($"Марка и модель: {_Name}");
            Console.WriteLine($"Всего безина: {_maxOil}");
            Console.WriteLine($"Тип бензина: {_Gas}");
            Console.WriteLine($"Текущий уровень бензина: {_nowOil}");
        }
    }

    // легковые автомобили
    public class passegerCar : Car
    {
        public passegerCar(string name, Gas gas, int max, int now) : base(name, gas, max, now)
        {
            _Name = name;
            _Gas = gas;
            _maxOil = max;
            _nowOil = now;
        }
    }

    //тип автомобиля для легкового
    public class Audi : passegerCar
    {
        public Audi(string name, Gas gas, int max, int now) : base(name, gas, max, now)
        {
            _Name = name;
            _Gas = gas;
            _maxOil = max;
            _nowOil = now;
        }
    }

    //грузовые автомобили
    public class cargoCar : Car
    {
        public cargoCar(string name, Gas gas, int max, int now) : base(name, gas, max, now)
        {
            _Name = name;
            _Gas = gas;
            _maxOil = max;
            _nowOil = now;
        }
    }

    //тип автомобиля для грузового
    public class MAN : cargoCar
    {
        public MAN(string name, Gas gas, int max, int now) : base(name, gas, max, now)
        {
            _Name = name;
            _Gas = gas;
            _maxOil = max;
            _nowOil = now;
        }
    }


    //класс для заправки, где содержится имя бензина, кол-во бензина и его цена
    public class gasStation
    {
        public Gas _nameGas;
        public int _sizeGas;
        public int _priceGas;
        //конструктор(название бенз, сколько сейчас бензина опр типа и его цена)
        public gasStation(Gas gas, int size, int price)
        {
            _nameGas = gas;
            _sizeGas = size;
            _priceGas = price;
        }

        //вывод информации о бензине
        public void printGas()
        {
            Console.WriteLine($"Бензин: {_nameGas}");
            Console.WriteLine($"Кол-во бензина: {_sizeGas}");
            Console.WriteLine($"Цена бензина: {_priceGas}");
        }
    }


    //метод для заправки автомобиля
    public static void pourGas(Car car, gasStation gas, Worker wr)
    {
        wr.PrintWorker();
        car.printCar();
        gas.printGas();

        if (car._Gas != wr._Gas || wr._Gas != gas._nameGas)
        {
            Console.WriteLine("Работник не заправляет такой тип бензина");
        }
        else if (car._Gas != gas._nameGas)
        {
            Console.WriteLine("На этой колонке нет подходящего типа бензина");
        }
        else if (gas._sizeGas == 0)
        {
            Console.WriteLine("Такой бензин закончился");
        }
        else if (gas._sizeGas - (car._maxOil - car._nowOil) <= 0)
        {
            Console.WriteLine($"Залили все что было: {gas._sizeGas}");
        }
        else
        {
            Console.WriteLine($"В машину залили полный бак бензина, а именно: {car._maxOil - car._nowOil}");
        }
    }



    static void Main(string[] args)
    {
        Worker adam = new Worker("Adam", Gas.A92); // в скобках указываются его характеристики(имя - адам, типа топлива - 92)
        Worker lisa = new Worker("Lisa", Gas.A100); //имя - лиза, типа - 100

        //для удобства засунуть в лист дял работникв
        List<Worker> workers = new List<Worker> { adam, lisa };

        Audi audi = new Audi("A4", Gas.A100, 70, 12);//легковой автомобиль: модель - А4, тип бенз - 100, макс - 70, сейчас - 12
        MAN man = new MAN("F90", Gas.A92, 100, 50);//грузовой автомобиль: модель - F90, тип бенз - 92, макс - 100, сейчас - 50

        //лист с автомобилями
        List<Car> cars = new List<Car> { audi, man };

        gasStation firstGas = new gasStation(Gas.A100, 500, 50);
        gasStation secondGas = new gasStation(Gas.A92, 40, 40);

        //лист с бензином
        List<gasStation> gasStations = new List<gasStation> { firstGas, secondGas };

        Console.WriteLine("first car----------------");
        pourGas(cars[0], gasStations[0], workers[1]);//ауди, бензин 100, работник Лиза
        Console.WriteLine("next car-----------------");
        pourGas(cars[1], gasStations[1], workers[0]);//man, безин 92, работник Адам
        Console.WriteLine("next car-----------------");
        pourGas(cars[1], gasStations[1], workers[1]);//man, безин 92, работник Лиза
        Console.ReadKey();
    }
}

