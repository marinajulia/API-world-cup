using System.ComponentModel;

namespace WorldCup.SharedKernel.UserMessages
{
    public enum UserMessagesEnum
    {
        [Description("Não foi possível encontrar o valor procurado.")]
        notFound,
        [Description("Não foi possível remover o valor.")]
        couldNotRemove,
        [Description("Não foi possível atualizar o valor.")]
        couldNotUpdate,
        [Description("Não foi possível criar este valor.")]
        couldNotCreate,

        [Description("Time não encontrado")]
        teamNotFound,
        [Description("Não foi encontrado nenhum jogador para este time")]
        playersNotFound,
    }
}
