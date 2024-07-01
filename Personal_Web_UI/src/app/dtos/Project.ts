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

    constructor(projectName?: string, ProjectDescription?: string, projectUrl?: string, ImageUrl?: string) {
        this.ProjectName = projectName;
        this.ProjectDescription = ProjectDescription;
        this.ProjectUrl = projectUrl;
        this.ImageUrl = ImageUrl;
    }
}

export class UpdateProject {
    id?: number;
    projectName?: string;
    projectDescription?: string;
    projectUrl?: string;
    imageUrl?: string;

    constructor(id?: number, projectName?: string, ProjectDescription?: string, projectUrl?: string, imageUrl?: string){
        this.id = id;
        this.projectName = projectName;
        this.projectDescription = ProjectDescription;
        this.projectUrl = projectUrl;
        this.imageUrl = imageUrl;
    }
}