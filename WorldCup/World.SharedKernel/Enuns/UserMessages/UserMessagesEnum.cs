using System.ComponentModel;

namespace WorldCup.SharedKernel.Enuns.UserMessages
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

        [Description("Não foi encontrado nenhum usuário")]
        userNotFound,
        [Description("Usuário já bloqueado")]
        userAlreadyBlocked,
        [Description("Usuário já desbloqueado")]
        userAlreadyUnblocked,
        [Description("Usuário bloqueado com sucesso")]
        successfullyBlockedUser,
        [Description("Existem campos vazios!")]
        emptyFields,
        [Description("Usuário ou senha incorretos!")]
        incorrectUsernameOrPassword,
        [Description("Usuário logado com sucesso!")]
        userLoggedInSuccessfully,
        [Description("Não foi possível alterar a senha")]
        UnableToChangePassword,
        [Description("Senha alterada com sucesso")]
        PasswordChangedSuccessfully,
    }
}
