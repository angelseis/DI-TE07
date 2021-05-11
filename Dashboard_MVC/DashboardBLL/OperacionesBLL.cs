using System;
using System.Collections.Generic;
using System.Text;
using DashboardDAL;
using DashboardUtilidades;

namespace DashboardBLL
{
    public class OperacionesBLL
    {
        private DashboardVO dashboardVO;
        public OperacionesBLL(DashboardVO dashboardVO)
        {
            this.dashboardVO = dashboardVO;
        }
        public OperacionesBLL()
        {
        }

        public String[,] CrearArrayComerciales(DashboardVO dashboardVO)
        {
            OperacionesDAL operacionesDAL = new OperacionesDAL();
            String[,] arrayCom = operacionesDAL.CrearArrayComerciales(dashboardVO);
            return arrayCom;
        }
        public String[,] CrearArrayVentas(DashboardVO dashboardVO)
        {
            OperacionesDAL operacionesDAL = new OperacionesDAL();
            String[,] arrayCom = operacionesDAL.CrearArrayVentas(dashboardVO);
            return arrayCom;
        }

        public String[] datosPersonales(String[,] arrayComerciales, String comElegido)
        {
            OpUtilidades opUtilidades = new OpUtilidades();
            String[] datosComerciales = opUtilidades.BuscarDatos(arrayComerciales, comElegido);
            return datosComerciales;
        }

        public int[] datosFacturacion(String[,] arrayVentas, String comElegido)
        {
            OpUtilidades opUtilidades = new OpUtilidades();
            int[] datosFacturacion = opUtilidades.BuscarFacturacion(arrayVentas, comElegido);
            return datosFacturacion;
        }

        public int[] CrearSeries(String[,] arrayVentas , String numEmpresa, String comElegido)
        {
            OpUtilidades opUtilidades = new OpUtilidades();
            int[] series = opUtilidades.CrearSeriesGrafico (arrayVentas, numEmpresa, comElegido);
            return series;
        }

    }
}
