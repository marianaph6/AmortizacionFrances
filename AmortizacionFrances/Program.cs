// See https://aka.ms/new-console-template for more information
using System.Data;
using DataTablePrettyPrinter;

long monto = 0;
    int meses=0;
float interes = 0, amortizacion = 0, saldo_inicial = 0, saldo_restante = 0, cuota = 0,tasa = 0;


Console.WriteLine("Bienvenido! \n Vamos a calcular la amortización");


Console.WriteLine("Ingrese el valor del capital prestado");
monto = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Ingrese el valor del interes");
tasa = ((float)Convert.ToDouble(Console.ReadLine()));

Console.WriteLine("Ingrese el número de períodos");
meses = Convert.ToInt32(Console.ReadLine());

// Create a new DataTable.
DataTable tabla = new DataTable();
tabla.TableName = "Amortización";


// Se tiene que crear primero la columna asignandole Nombre y Tipo de datos    
tabla.Columns.Add("Mes", typeof(int));
tabla.Columns.Add("Saldo Inicial", typeof(float));
tabla.Columns.Add("Interes", typeof(float));
tabla.Columns.Add("Pago Mensual (Amortización)", typeof(float));
tabla.Columns.Add("Cuota Mensual Fija", typeof(float));
tabla.Columns.Add("Saldo Restante", typeof(float));

saldo_inicial = monto;

cuota = (float)(monto * (Math.Pow(1 + tasa / 100, meses) * tasa / 100) / (Math.Pow(1 + tasa / 100, meses) - 1));
for (int i = 1; i <= meses; i++)
{

    interes = saldo_inicial * (tasa/100);
    amortizacion = (cuota - interes);
    saldo_restante = saldo_inicial - amortizacion;

    if (saldo_restante < 0) {
        saldo_restante = 0;
    }
    tabla.Rows.Add(i,saldo_inicial,interes,amortizacion,cuota,saldo_restante);

    saldo_inicial = saldo_restante;
}

Console.WriteLine(tabla.ToPrettyPrintedString());
