using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace REDENCAO._4
{
    public class Som
    {
        private SoundPlayer player;

        // Toca um som em loop de forma assíncrona.
        public async Task<bool> TocarSomEmLoopAsync(string caminhoAudio)
        {
            try
            {
                if (player != null)
                {
                    player.Stop(); // Para qualquer som anterior
                }

                player = new SoundPlayer(caminhoAudio);
                player.Load();

                player.PlayLooping(); // Reproduz o som em loop
                return true; // Indica sucesso
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao tentar tocar o som em loop: {ex.Message}");
                return false; // Indica falha
            }
        }

        // Para qualquer som que esteja sendo reproduzido.
        public async Task<bool> PararSomAsync()
        {
            try
            {
                if (player != null)
                {
                    player.Stop();
                    player = null; // Libera o player
                }
                return true; // Indica sucesso
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao tentar parar o som: {ex.Message}");
                return false; // Indica falha
            }
        }

        // Toca um som único de forma assíncrona.
        public async Task<bool> TocarSomUnicoAsync(string caminhoAudio)
        {
            try
            {
                if (player != null)
                {
                    player.Stop(); // Para qualquer som anterior
                }

                player = new SoundPlayer(caminhoAudio);
                player.Load();
                player.PlaySync(); // Reproduz o som e aguarda até o fim
                return true; // Indica sucesso
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao tentar tocar o som único: {ex.Message}");
                return false; // Indica falha
            }
        }
    }
}