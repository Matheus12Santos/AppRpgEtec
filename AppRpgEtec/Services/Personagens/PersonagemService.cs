﻿using AppRpgEtec.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRpgEtec.Services.Personagens
{
    public class PersonagemService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "https://rpgmatheusluca-byg2ahdsf6eda8d0.brazilsouth-01.azurewebsites.net/Personagens";

        private string _token;
        public PersonagemService(string token)
        {
            _request = new Request();
            _token = token;
        }

        public async Task<int> PostPersonagemAsync(Personagem p)
        {
            return await _request.PostReturnIntAsync(apiUrlBase, p, _token);
        }
        public async Task<ObservableCollection<Personagem>> GetPersonagensAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll"); ObservableCollection<Models.Personagem> listaPersonagens = await _request.GetAsync<ObservableCollection<Models.Personagem>>(apiUrlBase + urlComplementar, _token);
            return listaPersonagens;
        }
        public async Task<Personagem> GetPersonagemAsync(int personagemId)
        {
            string urlComplementar = string.Format("/{0}", personagemId); var personagem = await _request.GetAsync<Models.Personagem>(apiUrlBase + urlComplementar, _token);
            return personagem;
        }
        public async Task<int> PutPersonagemAsync(Personagem p)
        {
            var result = await _request.PutAsync(apiUrlBase, p, _token); return result;
        }
        public async Task<int> DeletePersonagemAsync(int personagemId)
        {
            string urlComplementar = string.Format("/{0}", personagemId); var result = await _request.DeleteAsync(apiUrlBase + urlComplementar, _token); return result;
        }
    }
}
