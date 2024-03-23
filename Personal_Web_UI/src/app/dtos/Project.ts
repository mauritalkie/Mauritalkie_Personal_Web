export class CreateProject {
    constructor(projectName: string, projectUrl: string, ImageUrl: string) {
        this.ProjectName = projectName;
        this.ProjectUrl = projectUrl;
        this.ImageUrl = ImageUrl;
    }

    ProjectName?: string;
    ProjectUrl?: string;
    ImageUrl?: string;
}

export class UpdateProject {
    constructor(id: number, projectName: string, projectUrl: string, imageUrl: string){
        this.id = id;
        this.ProjectName = projectName;
        this.ProjectUrl = projectUrl;
        this.ImageUrl = imageUrl;
    }

    id?: number;
    ProjectName?: string;
    ProjectUrl?: string;
    ImageUrl?: string;
}