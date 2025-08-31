<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:ns="http://tempuri.org/congty.xsd"
    exclude-result-prefixes="ns"
>
	<xsl:output method="html" indent="yes"/>

	<xsl:template match="/">
		<html>
			<head>
				<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
				<style>
					.container{
						width: 500px;
						margin: 0 auto;
						text-align: center;
						border: 1px solid black;
						padding: 1rem;
					}
					.content{
						display: flex;
						justify-content: space-around;
					}
					h1{
						color: #0070c0;
						text-transform: uppercase;
						text-align: center;
					}
					table{
						border: 1px solid black;
						border-collapse: collapse;
						margin: 0 auto;
					}
					th,td{
						border: 1px solid;
						padding: 10px;
					}
				</style>		
			</head>
			<body>
				<h1>Thông tin công ty</h1>
				<xsl:for-each select="ns:congty/ns:phongban">
					<div class="container">
						<div class="content">
							<p>
								Tên phòng: <strong>
									<xsl:value-of select="ns:tenphong" />
								</strong>
							</p>
							<p>
								Điện thoại: <strong>
									<xsl:value-of select="ns:dienthoai" />
								</strong>
							</p>
						</div>
						<table>
							<tr>
								<th>Mã nhân viên</th>
								<th>Họ tên</th>
								<th>Trình độ</th>
								<th>Mức lương</th>
							</tr>
							<tr>
								<td></td>
							</tr>
						</table>
					</div>
				</xsl:for-each>

			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
