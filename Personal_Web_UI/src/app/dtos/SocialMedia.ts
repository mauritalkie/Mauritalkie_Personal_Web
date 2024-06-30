export class GetSocialMedia {
    id?: number;
    socialMediaName?: string;
    socialMediaUrl?: string;
}

export class CreateSocialMedia {
    socialMediaName?: string;
    socialMediaUrl?: string;
    socialMediaUserId?: number;
    
    constructor(socialMediaName: string, socialMediaUrl: string, socialMediaUserId: number) {
        this.socialMediaName = socialMediaName;
        this.socialMediaUrl = socialMediaUrl;
        this.socialMediaUserId = socialMediaUserId;
    }
 }

 export class UpdateSocialMedia { 
    id?: number;
    socialMediaName?: string;
    socialMediaUrl?: string;

    constructor(id: number, socialMediaName: string, socialMediaUrl: string) {
        this.id = id;
        this.socialMediaName = socialMediaName;
        this.socialMediaUrl = socialMediaUrl;
    }
  }