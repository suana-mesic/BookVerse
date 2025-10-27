export type RegisterResponse = {
    userId: number,
    accessToken?: string;
    refreshToken?: string;
    expiresAtUtc?: string;
}
