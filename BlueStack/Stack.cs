using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueStack
{
    /// <summary>
    /// Classe que implementa uma stack com os métodos Push, Pop e Min, com O(1)  
    /// </summary>
    public class Stack
    {
        private Stack<int> _items;

        /// <summary>
        /// Armazena o menor valor atual
        /// </summary>
        private int _minimum;
        private int Minimum => _minimum; // body notation do c# 6.0

        public Stack()
        {
            _items = new Stack<int>();
        }

        /// <summary>
        /// Realiza inserção do elemento no topo da pilha
        /// </summary>
        /// <param name="value"></param>
        public void Push(int value)
        {
            // caso push() primeiro elemento na pilha atualizo o menor valor atual, isso garante também que o menor valor seja sempre atualizado mesmo após operações de Pop() que esvaziem toda pilha
            if (!_items.Any())
                _minimum = value;

            // A ideia aqui é utilizar a mesma estrutura de Stack para armazenar o menor valor anterior
            // e durante a operação de Pop() executo duas vezes a operação caso o menor valor atual seja o elemento removido
            // tinha duas soluções em mente, a outra seria utilizar uma segunda estrutura de pilha que armazenasse os valores minimos a cada push
            // essa funcionou melhor pois economizou alocação de uma segunda estrutura de stack e atendeu a implementação dos 3 métodos: Push, Pop, Min
            if (value <= _minimum)
            {
                // O push nativo do .NET é O(1) por isso não preciso me preocupar em calcular o big o de codigo nativo. Ref.: https://github.com/dotnet/corefx/blob/master/src/System.Collections/src/System/Collections/Generic/Stack.cs
                _items.Push(_minimum);
                _minimum = value;
            }
            _items.Push(value);
        }

        /// <summary>
        /// Retorna e remove o elemento no topo da pilha
        /// </summary>
        /// <returns></returns>
        public int Pop()
        {
            // O pop nativo do .NET é O(1) por isso não preciso me preocupar em calcular o big o de codigo nativo. Ref.: https://github.com/dotnet/corefx/blob/master/src/System.Collections/src/System/Collections/Generic/Stack.cs
            var result = _items.Pop();
            if (result == _minimum )
                _minimum = _items.Pop();
            // Caso pop() do ultimo elemento da pilha, apenas para manter 
            if (!_items.Any())
                _minimum = default(int);
            return result;
        }

        /// <summary>
        /// Retorna o menor inteiro da fila
        /// </summary>
        /// <returns></returns>
        public int Min()
        {
            return Minimum;
        }
    }
}
