export class DisplayUserInfo {
    username?: string;
    userPictureUrl?: string;
    aboutMeDescription?: string;
}

export class LoginUser {
    id?: number;
    username?: string;
    userPassword?: string;
}

export class SessionUser {
    token: string = '';
}