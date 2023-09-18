using Microsoft.AspNetCore.Identity;

namespace HSDWebApp.Common.Identity
{
    /// <summary>
    /// IdentityErrorDescriber の日本語ローカライズクラス
    /// </summary>
    public class JapaneseIdentityErrorDescriber : IdentityErrorDescriber
    {
        /// <summary>
        /// 予期されないエラー
        /// </summary>
        /// <returns></returns>
        public override IdentityError DefaultError()
        {
            return new IdentityError
            {
                Code = nameof(DefaultError),
                Description = $"不明なエラーが発生しました。"
            };
        }

        /// <summary>
        /// 並行処理失敗エラー
        /// </summary>
        /// <returns></returns>
        public override IdentityError ConcurrencyFailure()
        {
            return new IdentityError
            {
                Code = nameof(ConcurrencyFailure),
                Description = "データが変更されたため楽観的並行性処理に失敗しました。"
            };
        }

        /// <summary>
        /// パスワード不一致エラー
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordMismatch()
        {
            return new IdentityError
            {
                Code = nameof(PasswordMismatch),
                Description = "パスワードが一致しません。"
            };
        }

        /// <summary>
        /// トークン失効エラー
        /// </summary>
        /// <returns></returns>
        public override IdentityError InvalidToken()
        {
            return new IdentityError
            {
                Code = nameof(InvalidToken),
                Description = "トークンが無効です。"
            };
        }

        /// <summary>
        /// リカバリコード引き換えエラー
        /// </summary>
        /// <returns></returns>
        public override IdentityError RecoveryCodeRedemptionFailed()
        {
            return new IdentityError
            {
                Code = nameof(RecoveryCodeRedemptionFailed),
                Description = "リカバリーコードの引き換えに失敗しました。"
            };
        }

        /// <summary>
        /// ログイン情報連携済みエラー
        /// </summary>
        /// <returns></returns>
        public override IdentityError LoginAlreadyAssociated()
        {
            return new IdentityError
            {
                Code = nameof(LoginAlreadyAssociated),
                Description = "このログイン情報はすでに他のアカウントで使用されています。"
            };
        }

        /// <summary>
        /// ユーザー名バリデートエラー
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(InvalidUserName),
                Description = $"'{userName}' は無効なユーザー名です。文字、もしくは数字のみ使用可能です。"
            };
        }

        /// <summary>
        /// メールアドレスバリデートエラー
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError
            {
                Code = nameof(InvalidEmail),
                Description = $" '{email}' は無効なメールアドレスです。"
            };
        }

        /// <summary>
        /// 重複ユーザー名エラー
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateUserName),
                Description = $"'{userName}' はすでに使用されているユーザー名です。"
            };
        }

        /// <summary>
        /// 重複メールアドレスエラー
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateEmail),
                Description = $"'{email}' は既に使用されているメールアドレスです。"
            };
        }

        /// <summary>
        /// ロール名バリデートエラー
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public override IdentityError InvalidRoleName(string role)
        {
            return new IdentityError
            {
                Code = nameof(InvalidRoleName),
                Description = $"'{role}' は無効なロール名です。"
            };
        }

        /// <summary>
        /// 重複ロール名エラー
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public override IdentityError DuplicateRoleName(string role)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateRoleName),
                Description = $"'{role}' は既に使用されているロール名です。"
            };
        }

        /// <summary>
        /// パスワード設定済みエラー
        /// </summary>
        /// <returns></returns>
        public override IdentityError UserAlreadyHasPassword()
        {
            return new IdentityError
            {
                Code = nameof(UserAlreadyHasPassword),
                Description = "すでにパスワードが設定されています。"
            };
        }

        /// <summary>
        /// ロックアウト無効エラー
        /// </summary>
        /// <returns></returns>
        public override IdentityError UserLockoutNotEnabled()
        {
            return new IdentityError
            {
                Code = nameof(UserLockoutNotEnabled),
                Description = "このユーザーはロックアウトが有効になっていません。"
            };
        }

        /// <summary>
        /// 所属ロール重複エラー
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public override IdentityError UserAlreadyInRole(string role)
        {
            return new IdentityError
            {
                Code = nameof(UserAlreadyInRole),
                Description = $"ユーザーは既にロール '{role}' に所属しています。"
            };
        }

        /// <summary>
        /// ユーザーロール未所属エラー
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public override IdentityError UserNotInRole(string role)
        {
            return new IdentityError
            {
                Code = nameof(UserNotInRole),
                Description = $"ユーザーはロール '{role}' に所属していません。"
            };
        }

        /// <summary>
        /// パスワードポリシーエラー（長さ）
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = nameof(PasswordTooShort),
                Description = $"パスワードの文字数は {length} 以上である必要があります。"
            };
        }

        /// <summary>
        /// パスワードポリシーエラー（文字組み合わせ）
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public override IdentityError PasswordRequiresUniqueChars(int length)
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresUniqueChars),
                Description = $"パスワードの文字列は {length} 以上の一意な文字の組み合わせである必要があります。"
            };
        }

        /// <summary>
        /// パスワードポリシーエラー（記号）
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = "パスワードは少なくとも 1 文字以上の記号を含む必要があります。"
            };
        }

        /// <summary>
        /// パスワードポリシーエラー（数値）
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresDigit),
                Description = "パスワードは少なくとも 1 文字以上の数字('0'-'9')を含む必要があります。"
            };
        }

        /// <summary>
        /// パスワードポリシーエラー（小文字）
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresLower),
                Description = "パスワードは少なくとも 1 文字以上の小文字('a'-'z')を含む必要があります。"
            };
        }

        /// <summary>
        /// パスワードポリシーエラー（大文字）
        /// </summary>
        /// <returns></returns>
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresUpper),
                Description = "パスワードは少なくとも 1 文字以上の小文字('A'-'Z')を含む必要があります。"
            };
        }
    }
}
