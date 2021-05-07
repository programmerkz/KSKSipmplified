using System;


namespace KSKSimplified.KSK.Models
{
    /// <summary>Класс <c>User</c> описывает Пользователя.</summary>
    public class User
    {
        public string Login { get; }
        public string PasswordHash { get; set; }

        /// <summary>Создает новый объект Пользователь</summary>
        /// <param name="login">Логин, должен быть не NULL и не пустым</param>
        /// <param name="password">Пароль, должен быть не NULL и не пустым</param>
        public User(string login, string password)
        {
            if ((login == null) || (password == null))
                throw new ArgumentNullException();

            if ((login == "") || (password == ""))
                throw new ArgumentException();

            Login = login;
            PasswordHash = GetHashMoc(password);
        }

        /// <summary>Сверяет значение хэша от переданного пароля <c>password</c> со значением хэша, которое хранится в свостве <c>PasswordHash</c></summary>
        /// <param name="password">пароль для проверки, соответствует ли хэш от этого пароля хэшу, хранящемуся в свойстве <c>PasswordHash</c></param>
        public bool IsAuth(string password)
            => PasswordHash == GetHashMoc(password);

        /// <summary>Метод <c>GetHashMoc</c> является макетом (эмулирует поведение) Хэш-фукнции.</summary>
        private string GetHashMoc(string password)
            => password + "_hash";
    }
}
