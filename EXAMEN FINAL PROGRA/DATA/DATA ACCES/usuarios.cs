using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EXAMEN_FINAL_PROGRA.DATA.DATA_ACCES
{
    internal class usuarios2
    {
        public int id { get; set; }
        public string placa { get; set; }
        public string nombre { get; set; }
        public string marca { get; set; }
        public string dpi { get; set; }
        public decimal precio { get; set; }
        public bool saldo { get; set; }
        public int numero { get; set; }
        public string des { get; set; }
        public DateTime fecha1 { get; set; }
        public DateTime fecha2
        {
            get; set;
        }
        // Constructor sin parámetros
        public usuarios2() { }

        // Constructor con parámetros
        public usuarios2(int id, string placa, string nombre, string marca, string dpi, decimal precio, bool saldo, string numero, string des, DateTime fecha1, DateTime fecha2)
        {
            id = id;
            placa = placa;
            nombre = nombre;
            marca = marca;
            dpi = dpi;
            precio = precio;
            saldo = saldo;
            numero = numero;
            des = des;
            fecha1 = fecha1;
            fecha2 = fecha2;




        }
        // Método para mostrar información del usuario
        public override string ToString()
        {
            return $"id: {id}, placa: {placa}, nombre: {nombre}, marca: {marca}, dpi: {dpi}, precio: {precio:C}, saldo: {saldo}, numero: {numero}, des: {des}, fecha1: {fecha1}, fecha2: {fecha2}";
        }
    }
}
