export interface MessageModel {
    type:any,
    text:any,
    customMessageData: CustomMessageData[],
    reply: boolean,
    date: any,
    user: User[]
    
}

 export interface CustomMessageData {
    href:any,
    text:any,
}

 export interface User {
    name:any,
    avatar:any,
}