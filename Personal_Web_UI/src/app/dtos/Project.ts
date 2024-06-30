export class GetProject {
    id?: number;
    projectName?: string;
    projectDescription?: string;
    projectUrl?: string;
    imageUrl?: string;
}

export class CreateProject {
    ProjectName?: string;
    ProjectDescription?: string;
    ProjectUrl?: string;
    ImageUrl?: string;
    projectUserId?: number;

    constructor(projectName: string, ProjectDescription: string, projectUrl: string, ImageUrl: string, projectUserId: number) {
        this.ProjectName = projectName;
        this.ProjectDescription = ProjectDescription;
        this.ProjectUrl = projectUrl;
        this.ImageUrl = ImageUrl;
        this.projectUserId = projectUserId;
    }
}

export class UpdateProject {
    id?: number;
    ProjectName?: string;
    ProjectDescription?: string;
    ProjectUrl?: string;
    ImageUrl?: string;

    constructor(id: number, projectName: string, ProjectDescription: string, projectUrl: string, imageUrl: string){
        this.id = id;
        this.ProjectName = projectName;
        this.ProjectDescription = ProjectDescription;
        this.ProjectUrl = projectUrl;
        this.ImageUrl = imageUrl;
    }
}