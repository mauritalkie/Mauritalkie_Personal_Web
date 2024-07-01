export class GetSocialMedia {
    id?: number;
    socialMediaName?: string;
    socialMediaUrl?: string;
}

export class CreateSocialMedia {
    socialMediaName?: string;
    socialMediaUrl?: string;
    
    constructor(socialMediaName?: string, socialMediaUrl?: string) {
        this.socialMediaName = socialMediaName;
        this.socialMediaUrl = socialMediaUrl;
    }
 }

 export class UpdateSocialMedia { 
    id?: number;
    socialMediaName?: string;
    socialMediaUrl?: string;

    constructor(id?: number, socialMediaName?: string, socialMediaUrl?: string) {
        this.id = id;
        this.socialMediaName = socialMediaName;
        this.socialMediaUrl = socialMediaUrl;
    }
  }