export interface Message {
    fromUser: boolean;
    campoId: string;
    sentMessage: string[];
    messageCategory: string;
    sentMessageDatetime: Date;
}