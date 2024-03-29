export class GetProject {
    Id?: number;
    ProjectName?: string;
    ProjectDescription?: string;
    ProjectUrl?: string;
    ImageUrl?: string;

    constructor(Id: number, projectName: string, projectDescription: string, projectUrl: string, imageUrl: string) {
        this.Id = Id;
        this.ProjectName = projectName;
        this.ProjectDescription = projectDescription;
        this.ProjectUrl = projectUrl;
        this.ImageUrl = imageUrl;
    }
}

export class CreateProject {
    ProjectName?: string;
    ProjectDescription?: string;
    ProjectUrl?: string;
    ImageUrl?: string;

    constructor(projectName: string, ProjectDescription: string, projectUrl: string, ImageUrl: string) {
        this.ProjectName = projectName;
        this.ProjectDescription = ProjectDescription;
        this.ProjectUrl = projectUrl;
        this.ImageUrl = ImageUrl;
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