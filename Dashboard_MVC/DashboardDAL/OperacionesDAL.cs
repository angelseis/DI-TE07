using DashboardUtilidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DashboardDAL
{
    public class OperacionesDAL
    {
        public OperacionesDAL()
        {

        }
        //Llama al método CSV_ToArray para crear el array con los datos de los comerciales
        public String[,] CrearArrayComerciales(DashboardVO dashboardVO)
        {
            String fichero = "../" + dashboardVO.FileComerciales;
            String[,] miArray = CSV_ToArray(@fichero, ",");

            return miArray;
        }

        //Llama al método CSV_ToArray para crear el array de ventas
        public String[,] CrearArrayVentas(DashboardVO dashboardVO)
        {
            String fichero = "../" + dashboardVO.FileVentas;
            String[,] miArray = CSV_ToArray(@fichero, ",");

            return miArray;
        }

        // Método que crea un array bidimensional a partir de un archivo csv
        private static string[,] CSV_ToArray(string path, string separator = ";")
        {
            // comprueba si existe el fichero
            if (!File.Exists(path))
                throw new FileNotFoundException("No se encuentra el archivo");

            // Lista temporal para guardar la información
            List<string[]> tempList = new List<string[]>();

            var rd = new StreamReader(File.OpenRead(path));

            while (!rd.EndOfStream)
            {
                // lee la linea
                string linea = rd.ReadLine();
                string[] valores = linea.Split(separator.ToCharArray());

                // añadimos a la lista
                tempList.Add(valores);
            }
            // Convierte la lista en array [][]
            String[][] datos = tempList.ToArray();

            // Convierte el array [][] en array [,]
            String[,] resultado = new string[datos.Length, datos[0].Length];
            for (int j = 0; j < datos.Length; j += 1)
            {
                for (int k = 0; k < datos[j].Length; k += 1)
                {
                    resultado[j, k] = datos[j][k];
                }
            }
            // devuelve el array [,] creado
            return resultado;
        }
    }
}
