using TP_1_ARCE_GERMAN;

namespace TP_1_ARCE_GERMAN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //creamos el arbol binario
            ArbolBinario<int> arbolBinarioA = new ArbolBinario<int>(1);
            //creamos los hijos del arbol binario

            ArbolBinario<int> hijoIzquierdo = new ArbolBinario<int>(2);
            hijoIzquierdo.agregarHijoIzquierdo(new ArbolBinario<int>(4));
            //creamos el hijo derecho del arbol binario

            ArbolBinario<int> hijoDerecho = new ArbolBinario<int>(3);
            hijoDerecho.agregarHijoIzquierdo(new ArbolBinario<int>(5));
            hijoDerecho.agregarHijoDerecho(new ArbolBinario<int>(6));
            //  agregamos los hijos al arbol binario

            arbolBinarioA.agregarHijoIzquierdo(hijoIzquierdo);
            arbolBinarioA.agregarHijoDerecho(hijoDerecho);

            //llamamos al metodo nuevo
            ArbolBinario<int> arbolBinarioB = nuevo(arbolBinarioA);

            //imprimimos el arbol binario
            Console.WriteLine("Arbol binario A");
            arbolBinarioA.preorden();
            Console.WriteLine("Arbol binario B");
            arbolBinarioB.preorden();


            //imprimir si incluye un dato

            Console.WriteLine("El arbol binario A incluye el dato 5: " + arbolBinarioA.incluye(-9));


        }

        private static ArbolBinario<int> nuevo(ArbolBinario<int> arbol)
        {
            //creamos un arbol binario nuevo a partir de un arbol binario dado
            if (arbol == null)
            {
                return null;
            }

            ArbolBinario<int> nuevoArbol = new ArbolBinario<int>(arbol.getDatoRaiz());

           if (arbol.getHijoIzquierdo() != null)
            {
                int dato = arbol.getDatoRaiz() + arbol.getHijoIzquierdo().getDatoRaiz();
                nuevoArbol.agregarHijoIzquierdo(nuevo(new ArbolBinario<int>(dato)));

            }
            if (arbol.getHijoDerecho() != null)
            {
                int dato = arbol.getHijoDerecho().getDatoRaiz();
                nuevoArbol.agregarHijoDerecho(nuevo(arbol.getHijoDerecho()));
            }

            return nuevoArbol;
        }
    }
}
