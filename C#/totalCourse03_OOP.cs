using System;
using System.Runtime.CompilerServices;

namespace firstClass{
    /*-public: Acceso desde cualquier parte del codigo
    -private: Acceso solo dentro de la misma clase
    -protected: Acceso desde la misma clase y clases derivadas
    -internal: Acceso solo desde el mismo proyecto
    -protected internal: Acceso desde el mismo proyecto y clases derivadas
    -private protected: Acceso desde la misma clase y clases derivadas del mismo proyecto
    -file: Solo visible en archivo de origen actual. Se usan para generadores de origen.*/

    /*Interfaces: Plantilla con la declaracion de metodos y atributos que seran obligatorios
     para clase derivada*/
    public interface IPersona{
        void ShowInfo();
    }
    internal class Person : IPersona{
        //Atributos de clase
        protected string name;
        protected int age;
        protected float height;
        protected float weight;

        /*Encapsulamiento -> puede ser implementado a traves de getters y setters tradicionales o
        por propiedad Auto-implementada (podemos agregarle cuerpo al get o set, keyword (value) 
        hace referencia al valor ingresado)*/
        //Propiedades
        public string Name { get; } //Solo lectura 
        public int Age { //Lectura y escritura
            get { return age; }
            set { if (value < 0) throw new Exception("Number not allowed");
                age = value;
            } 
        } 
        public float Height { get; private set; } //Lectura desde fuera y modificable desde dentro
        public float Weight { get; set; } //Internamente funciona como un atributo privado

        //Metodos de clase
        
        //Constructores
        //Sobrecarga Constructores
        public Person() {
            name = string.Empty;
            age = 0;
            height = float.NaN;
            weight = float.NaN;
        }
        public Person(string _name,int _age){
            name = _name;
            age = _age;
            height = float.NaN;
            weight = float.NaN;
        }

        public Person(string _name, int _age, float _height, float _weight){
            name = _name;
            age = _age;
            height = _height;
            weight = _weight;
        }

        //Destructores (Son llamados automaticamente cuando el objeto no se vaya usar mas)
        //~Person(){ }

        public virtual void ShowInfo(){
            Console.WriteLine($"Name: {this.name}\nAge: {this.age}\nHeight: {this.height}\nWeight: {this.height}");
        }

        public static void OopMain(){
            Console.Write("Type your name -> ");
            var name = Console.ReadLine();
            Console.Write("Type your age -> ");
            var age = int.Parse(Console.ReadLine());
            Console.Write("Type your height (cms) -> ");
            var height = float.Parse(Console.ReadLine());
            Console.Write("Type your weight (kgs) -> ");
            var weight = float.Parse(Console.ReadLine());

            Person you = new Person(name, age, height, weight);
            you.ShowInfo();
        }
    };

    //Herencia: Nos permite heredar metodos y atributos de otra clase
    //Polimorfismo: Distintos comportamientos en clases derivadas a un mismo metodo
    /*Tipos metodos:
        abstract: Solo tiene su declaracion, su implentacion debe ser en clase derivada
        virtual: Tiene declaracion y puede ser implentado en clase base, y se 
            puede modificar desde clase derivada
        override: Sobreescribe metodo de clase base para modificar implentacion de en clase derivada, 
            sus retornos, parametros y nombre no pueden ser modificados
        sealed: Bloquear sobreescritura del metodo en clases derivadas, o bloquear clases para 
            evitar que no pueda ser heredada
        new: Permite modificar metodo de clase base, ocultandolo*/

    internal class Student : Person{
        public string Career { get; set; } 
        public string Univ { get; set; }
        
        public Student() {}
        public Student(string _u, string _career, string _name, int _age, 
                float _height, float _weight) : base(_name, _age, _height, _weight) {
            Univ = _u;
            Career = _career;
        }

        public override void ShowInfo(){
            Console.WriteLine($"Name: {this.name}\nCareer: {this.Career}\nUniversity: {this.Univ}\n" +
                $"Age: {this.age}\nHeight: {this.height}\nWeight: {this.height}");
        }
    }

}
