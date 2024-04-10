using PlayerBlazorApp.Models;

namespace PlayerBlazorApp.Services
{
    public class DoubleLinkedList
    {
        public Nodo?  PrimerNodo { get; set; }
        public Nodo?  UltimoNodo { get; set; }

        public Nodo? NodoActual  { get; set; }
        public DoubleLinkedList()
        {
            PrimerNodo = null;
            UltimoNodo = null;
            NodoActual = null;
        }

        public bool IsEmpty => PrimerNodo == null;

        public string AgregarNodoAlInicio(Nodo nuevoNodo)
        {
            if (IsEmpty)
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.LigaSiguiente = PrimerNodo;

                PrimerNodo.LigaAnterior = nuevoNodo;

                PrimerNodo = nuevoNodo;
            }

            NodoActual = nuevoNodo;

            return "Nodo agregado al inicio...";
        }
        public string AgregarNodoAlFinal(Nodo nuevoNodo)
        {
            if (IsEmpty)
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.LigaAnterior = UltimoNodo;

                UltimoNodo.LigaSiguiente = nuevoNodo;

                UltimoNodo = nuevoNodo;
            }

            NodoActual = nuevoNodo;

            return "Nodo agregado al Final...";
        }

        public Nodo Siguiente()
        {
            NodoActual = NodoActual.LigaSiguiente ?? UltimoNodo;
            return NodoActual;
        }

        public Nodo Anterior()
        {
            NodoActual = NodoActual.LigaAnterior ?? PrimerNodo;
            return NodoActual;
        }


    }
}
