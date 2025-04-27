from pydantic import BaseModel
#Validates API input/output data (Pydantic)

class UsernameCheckResponse(BaseModel):
    exists: bool

class ScoreCreate(BaseModel):
    player_name:str
    score:int

class ScoreOut(ScoreCreate):
    id:int

    class Config:
        from_attributes = True
