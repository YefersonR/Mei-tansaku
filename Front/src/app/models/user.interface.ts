export type Roles = 'SUSCRIPTOR' | 'ADMIN';

export interface User{
    userName: string;
    password: string;
}


export interface Main {
    payload:    Payload;
    success:    boolean;
    statuscode: number;
    message:    null;
}

export interface Payload {
    id:           string;
    name:         string;
    lastName:     string;
    userName:     null;
    email:        string;
    imageProfile: null;
    roles:        string[];
    isVerified:   boolean;
    jwToken:      string;
}