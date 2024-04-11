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
        //-----------------------------------------------------------------------------------------------------
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
                return "NODO AGREGADO EN POSICIÓN ESPECÍFICA ";
            }
        }
        public string AgregarAntesDeNodo(Nodo nodoExistente, Nodo nuevoNodo)
        {
            if (nodoExistente == null)
            {
                return "El nodo existente no puede ser nulo.";
            }

            nuevoNodo.LigaSiguiente = nodoExistente;
            nuevoNodo.LigaAnterior = nodoExistente.LigaAnterior;

            if (nodoExistente.LigaAnterior != null)
            {
                nodoExistente.LigaAnterior.LigaSiguiente = nuevoNodo;
            }
            else
            {
                PrimerNodo = nuevoNodo;
            }

            nodoExistente.LigaAnterior = nuevoNodo;
            NodoActual = nuevoNodo;

            return "Nodo agregado antes del nodo existente.";
        }
        public string AgregarDespuesDeNodo(Nodo nodoExistente, Nodo nuevoNodo)
        {
            if (nodoExistente == null)
            {
                return "El nodo existente no puede ser nulo.";
            }

            nuevoNodo.LigaAnterior = nodoExistente;
            nuevoNodo.LigaSiguiente = nodoExistente.LigaSiguiente;

            if (nodoExistente.LigaSiguiente != null)
            {
                nodoExistente.LigaSiguiente.LigaAnterior = nuevoNodo;
            }
            else
            {
                UltimoNodo = nuevoNodo;
            }

            nodoExistente.LigaSiguiente = nuevoNodo;
            NodoActual = nuevoNodo;

            return "Nodo agregado después del nodo existente.";
        }

        //-------------------------------------------------------------------------------------------------------
        
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

        //-----------------------------------------------------------------------------------------
        
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
       
        public Nodo? BuscarPorEnlace(string enlace)
        {
            Nodo? nodoActual = PrimerNodo;

            while (nodoActual != null)
            {
                if (nodoActual.Informacion == enlace)
                {
                    return nodoActual;
                }

                nodoActual = nodoActual.LigaSiguiente;
            }

            return null; // No se encontró el nodo con el enlace dado
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
        public string EliminarAntesDeNodo(Nodo nodoExistente)
        {
            if (nodoExistente == null || nodoExistente.LigaAnterior == null)
            {
                return "No se puede eliminar el elemento antes del nodo existente.";
            }

            Nodo nodoAEliminar = nodoExistente.LigaAnterior;
            Nodo nodoAnterior = nodoAEliminar.LigaAnterior;

            if (nodoAnterior != null)
            {
                nodoAnterior.LigaSiguiente = nodoExistente;
            }
            else
            {
                PrimerNodo = nodoExistente;
            }

            nodoExistente.LigaAnterior = nodoAnterior;
            NodoActual = nodoExistente;

            return "Elemento eliminado antes del nodo existente.";
        }
        public string EliminarDespuesDeNodo(Nodo nodoExistente)
        {
            if (nodoExistente == null || nodoExistente.LigaSiguiente == null)
            {
                return "No se puede eliminar el elemento después del nodo existente.";
            }

            Nodo nodoAEliminar = nodoExistente.LigaSiguiente;
            Nodo nodoSiguiente = nodoAEliminar.LigaSiguiente;

            nodoExistente.LigaSiguiente = nodoSiguiente;

            if (nodoSiguiente != null)
            {
                nodoSiguiente.LigaAnterior = nodoExistente;
            }
            else
            {
                UltimoNodo = nodoExistente;
            }

            NodoActual = nodoExistente;

            return "Elemento eliminado después del nodo existente.";
        }
        public string EliminarPorEnlace(string enlace)
        {
            Nodo nodoActual = PrimerNodo;
            Nodo nodoAnterior = null;

            // Buscar el nodo que contiene el enlace proporcionado
            while (nodoActual != null)
            {
                if (nodoActual.Informacion == enlace)
                {
                    // Eliminar el nodo encontrado
                    if (nodoAnterior != null)
                    {
                        nodoAnterior.LigaSiguiente = nodoActual.LigaSiguiente;
                        if (nodoActual.LigaSiguiente == null)
                        {
                            UltimoNodo = nodoAnterior;
                        }
                    }
                    else
                    {
                        // Si el nodo a eliminar es el primer nodo
                        PrimerNodo = nodoActual.LigaSiguiente;
                        if (PrimerNodo == null)
                        {
                            UltimoNodo = null; // Si la lista queda vacía
                        }
                    }

                    NodoActual = nodoAnterior != null ? nodoAnterior : PrimerNodo; // Actualizar el nodo actual

                    return "Elemento eliminado exitosamente.";
                }

                nodoAnterior = nodoActual;
                nodoActual = nodoActual.LigaSiguiente;
            }

            return "No se encontró ningún elemento con el enlace proporcionado.";
        }
        public string EliminarPorPosicion(int posicion)
        {
            if (posicion <= 0)
            {
                return "La posición debe ser un número positivo.";
            }

            if (IsEmpty)
            {
                return "La lista está vacía. No se puede eliminar el elemento.";
            }

            Nodo nodoAnterior = null;
            Nodo nodoActual = PrimerNodo;
            int contador = 1;

            // Recorrer la lista hasta llegar a la posición especificada
            while (nodoActual != null && contador < posicion)
            {
                nodoAnterior = nodoActual;
                nodoActual = nodoActual.LigaSiguiente;
                contador++;
            }

            // Verificar si se encontró la posición
            if (nodoActual == null)
            {
                return "La posición especificada está fuera del rango de la lista.";
            }

            // Eliminar el nodo en la posición especificada
            if (nodoAnterior != null)
            {
                nodoAnterior.LigaSiguiente = nodoActual.LigaSiguiente;
                if (nodoActual.LigaSiguiente == null)
                {
                    UltimoNodo = nodoAnterior; // Si el nodo a eliminar es el último
                }
            }
            else
            {
                PrimerNodo = nodoActual.LigaSiguiente; // Si el nodo a eliminar es el primero
                if (PrimerNodo == null)
                {
                    UltimoNodo = null; // Si la lista queda vacía
                }
            }

            NodoActual = nodoAnterior != null ? nodoAnterior : PrimerNodo; // Actualizar el nodo actual

            return "Elemento eliminado exitosamente.";
        }
        //----------------------------------------------------------------------------------------------
        public void OrdenarPorEnlace()
        {
            Nodo actual = PrimerNodo;

            while (actual != null)
            {
                Nodo minimo = actual;
                Nodo siguiente = actual.LigaSiguiente;

                while (siguiente != null)
                {
                    // Comparar enlaces y encontrar el mínimo
                    if (String.Compare(actual.Informacion, siguiente.Informacion) > 0)
                    {
                        minimo = siguiente;
                    }

                    siguiente = siguiente.LigaSiguiente;
                }

                // Intercambiar los enlaces de los nodos
                string temp = actual.Informacion;
                actual.Informacion = minimo.Informacion;
                minimo.Informacion = temp;

                actual = actual.LigaSiguiente;
            }
        }

        public string RecorridoRecursivo()
        {
            return RecorridoRecursivo(PrimerNodo);
        }

        private string RecorridoRecursivo(Nodo nodo)
        {
            if (nodo == null)
            {
                return string.Empty;
            }

            return nodo.Informacion + " -> " + RecorridoRecursivo(nodo.LigaSiguiente);
        }



    }

}
