CREATE TABLE IF NOT EXISTS artists(
  id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'update time',
  name varchar(255) comment 'Artist Full Name',
  
) default charset utf8 comment '';


CREATE TABLE IF NOT EXISTS pieces(
  id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'update time',
  title varchar(255) comment 'Title',
  artistId int NOT NULL COMMENT 'FK: Artist',

  FOREIGN KEY (artistId) REFERENCES artists(id) ON DELETE CASCADE

) default charset utf8 comment '';