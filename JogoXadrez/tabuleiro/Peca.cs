﻿namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtdMovimentos {get; protected set;}
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            posicao = null;
            this.cor = cor;
            this.tab = tab;
            qtdMovimentos = 0;
        }

        // Verifica se há movimentos possíveis através da matriz booleana de possibilidades
        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for(int i = 0; i < tab.linhas; i++)
            {
                for(int j = 0; j < tab.colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Método abstrato para as subclasses de Peça
        public abstract bool[,] movimentosPossiveis();


        public bool movimentoPossivel(Posicao pos)
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }

        public void incrementarQtdMovimentos()
        {
            qtdMovimentos++;
        }

        public void decrementarQtdMovimentos()
        {
            qtdMovimentos--;
        }
    }
}
