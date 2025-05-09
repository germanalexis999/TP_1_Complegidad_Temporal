﻿using System;
using System.Text.Json.Nodes;

namespace TP_1_ARCE_GERMAN
{
    public class ArbolBinario<T>
    {
        private T dato;
        private ArbolBinario<T>? hijoIzquierdo;
        private ArbolBinario<T>? hijoDerecho;

        public ArbolBinario(T dato)
        {
            this.dato = dato;
            this.hijoIzquierdo = null;
            this.hijoDerecho = null;
        }

        public T getDatoRaiz()
        {
            return this.dato;
        }

        public ArbolBinario<T>? getHijoIzquierdo()
        {
            return this.hijoIzquierdo;
        }

        public ArbolBinario<T>? getHijoDerecho()
        {
            return this.hijoDerecho;
        }

        public void agregarHijoIzquierdo(ArbolBinario<T> hijo)
        {
            this.hijoIzquierdo = hijo;
        }

        public void agregarHijoDerecho(ArbolBinario<T> hijo)
        {
            this.hijoDerecho = hijo;
        }

        public void eliminarHijoIzquierdo()
        {
            this.hijoIzquierdo = null;
        }

        public void eliminarHijoDerecho()
        {
            this.hijoDerecho = null;
        }

        public bool esHoja()
        {
            return this.hijoIzquierdo == null && this.hijoDerecho == null;
        }

        public void inorden()
        {

            if (this.hijoIzquierdo != null)
            {
                this.hijoIzquierdo.inorden();
            }

            Console.WriteLine(this.dato);

            if (this.hijoDerecho != null)
            {
                this.hijoDerecho.inorden();
            }


        }

        public void preorden()
        {

            Console.WriteLine(this.dato);

            if (this.hijoIzquierdo != null)
            {
                this.hijoIzquierdo.preorden();
            }
            if (this.hijoDerecho != null)
            {
                this.hijoDerecho.preorden();
            }
        }


        public void postorden()
        {

            

            if (this.hijoIzquierdo != null)
            {
                this.hijoIzquierdo.postorden();
            }
            if (this.hijoDerecho != null)
            {
                this.hijoDerecho.postorden();
            }
            Console.WriteLine(this.dato);
        }

        public void recorridoPorNiveles()
        {
            Cola<ArbolBinario<T>> cola = new Cola<ArbolBinario<T>>();
            cola.encolar(this);
            while (!cola.esVacia())
            {
                ArbolBinario<T> nodo = cola.desencolar();
                Console.WriteLine(nodo.getDatoRaiz());
                if (nodo.getHijoIzquierdo() != null)
                {
                    cola.encolar(nodo.getHijoIzquierdo());
                }
                if (nodo.getHijoDerecho() != null)
                {
                    cola.encolar(nodo.getHijoDerecho());
                }
            }
        }

        public int contarHojas()
        {
          

            if (this.esHoja())
            {
                return 1;
            }

            int hojas = 0;
            if (this.hijoIzquierdo != null)
            {
                hojas += this.hijoIzquierdo.contarHojas();
            }
            if (this.hijoDerecho != null)
            {
                hojas += this.hijoDerecho.contarHojas();
            }
            return hojas;
        }

        public bool incluye(T dato) {


            if (this.dato.Equals(dato))
            {
                return true;
            }

            bool encontrado= false;


            if (hijoIzquierdo != null)
            {
                encontrado = hijoIzquierdo.incluye(dato);
            }

            if (!encontrado && hijoDerecho != null)
            {
                encontrado = hijoDerecho.incluye(dato);
            }

            return encontrado;


        }



        public void recorridoEntreNiveles(int n, int m)
        {
            if (n < 0 || m < n)
            {
                throw new ArgumentException("Los niveles n y m deben cumplir 0 ≤ n ≤ m.");
            }

            int initialLevel = 0;
            Cola<(ArbolBinario<T> nodo, int level)> cola = new Cola<(ArbolBinario<T> nodo, int level)>();
       
            cola.encolar((this, initialLevel));

            while (!cola.esVacia())
            {
                var (nodo, level) = cola.desencolar();

                if (level > m)
                {
                    break;
                }

                if (level >= n && level <= m)
                {
                    Console.WriteLine(nodo.getDatoRaiz());
                }

                if (nodo.getHijoIzquierdo() != null)
                {
                    cola.encolar((nodo.getHijoIzquierdo(), level + 1));
                }

                if (nodo.getHijoDerecho() != null)
                {
                    cola.encolar((nodo.getHijoDerecho(), level + 1));
                }


            }

            }
    }
}
