using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen1DS39A.util
{
    public class Constantes
    {
        public Constantes()
        {

        }
        public string CONEXIONSTRING = Properties.Settings.Default.conexion;
        public  string cliente = "cliente";
        public  string administrador = "administrador";

        public string mostrarMensaje(string mensaje, string tipoAlerta)
        {
            string msj = "<div class='alert " + tipoAlerta + " alert - dismissible fade show' role='alert'>" + mensaje +
                          "<button type = 'button' class='close' data-dismiss='alert' aria-label='Close'>" +
                            "<span aria-hidden='true'>&times;</span>" +
                          "</button>" +
                        "</div>";
            return msj;
        }
    }


}