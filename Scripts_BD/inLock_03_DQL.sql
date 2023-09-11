USE inlock_games_Gabriel;

SELECT * FROM TiposUsuario;

SELECT * FROM Usuario;

SELECT * FROM Estudio;

SELECT * FROM Jogo;

SELECT Jogo.Nome AS Jogo,Estudio.Nome AS Estudio From Jogo
INNER JOIN Estudio
ON Jogo.IdEstudio = Estudio.IdEstudio;

SELECT Estudio.Nome AS Estudio,Jogo.Nome AS Jogo FROM Estudio
LEFT JOIN Jogo
ON Estudio.IdEstudio = Jogo.IdEstudio;

SELECT * FROM Usuario WHERE Email = 'cliente@cliente.com' AND Senha = 'cliente';

SELECT * FROM Jogo WHERE IdJogo = 4;

SELECT * FROM Estudio WHERE IdEstudio = 2;

SELECT Estudio.IdEstudio,Estudio.Nome,Jogo.Nome FROM Estudio
LEFT JOIN Jogo
ON Estudio.IdEstudio = Jogo.IdEstudio;



SELECT IdUsuario, Usuario.IdUsuario, Email,Usuario.Email FROM Usuario

SELECT IdUsuario, Usuario.IdTipoUsuario, Email FROM Usuario



SELECT IdUsuario, Usuario.Email FROM Usuario INNER JOIN TiposUsuario ON TiposUsuario.IdTipoUsuario = Usuario.IdUsuario


INSERT INTO TiposUsuario(Titulo) VALUES (@Titulo)

SELECT IdTipoUsuario, Titulo FROM TiposUsuario

SELECT IdJogo, Nome,Descricao,DataLancamento,Valor FROM Jogo