using PlayerBlazorApp.Models;

namespace PlayerBlazorApp.Services
{
    public class DoubleLinkedList
    {
        public Nodo? PrimerNodo { get; set; }
        public Nodo? UltimoNodo { get; set; }

        public Nodo? NodoActual { get; set; }
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
        public string AgregarEnPosicion(int posicion, Nodo nuevonodo)
        {
            if (IsEmpty || posicion <= 0)
            {
                return AgregarNodoAlInicio(nuevonodo);
            }

            if (posicion == 1)
            {
                return AgregarNodoAlInicio(nuevonodo);
            }
            else
            {
                Nodo nodoaux = PrimerNodo;
                int contador = 1;
                while (nodoaux != null && contador < posicion - 1)
                {
                    nodoaux = nodoaux.LigaSiguiente;
                    contador++;
                }
                if (nodoaux == null)
                {
                    return AgregarNodoAlFinal(nuevonodo);
                }
                else
                {
                    nuevonodo.LigaAnterior = nodoaux;
                    nuevonodo.LigaSiguiente = nodoaux.LigaSiguiente;
                    nodoaux.LigaSiguiente = nuevonodo;
                    nuevonodo.LigaAnterior.LigaSiguiente = nuevonodo;
                }
                NodoActual = nuevonodo;
                return "NODOA GREGADO EN POSICIION ESPECIFICA ";
            }
        }
        public Nodo Posicion(int posicion)
        {
            int contador = 1;
            while (contador < posicion-1 && NodoActual!=null )
            {
                posicion++;
                NodoActual = NodoActual.LigaSiguiente;
            }
            return NodoActual;
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
        public string EliminarNodoAlInicio ()
        {
            if (IsEmpty)
            {
                return "La lista está vacía. No se puede eliminar Video.";
            }
            else if (PrimerNodo == UltimoNodo)
            {

                PrimerNodo = null;
                UltimoNodo = null;
            }
            else
            {

                PrimerNodo = PrimerNodo.LigaSiguiente;
                PrimerNodo.LigaAnterior = null;
            }


            NodoActual = PrimerNodo;

            return "Nodo eliminado del Inicio...";
        }
        public string EliminarNodoAlFinal()
        {
            if (IsEmpty)
            {
                return "La lista está vacía. No se puede eliminar Video.";
            }
            else if (PrimerNodo == UltimoNodo)
            {
                
                PrimerNodo = null;
                UltimoNodo = null;
            }
            else
            {
               
                UltimoNodo = UltimoNodo.LigaAnterior;
                UltimoNodo.LigaSiguiente = null;
            }

            
            NodoActual = UltimoNodo;

            return "Nodo eliminado del final...";
        }


    }

}
